// <copyright file="LACE.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Framework.Security
{
    using System;
    using System.Text;
    using Gee.External.Capstone;
    using Gee.External.Capstone.X86;
    using UnicornManaged;
    using UnicornManaged.Const;

    internal class LACE
    {
        private static readonly Unicorn UC = new Unicorn(Common.UC_ARCH_X86, Common.UC_MODE_32);
        private static readonly CapstoneDisassembler disassembler = CapstoneDisassembler.CreateX86Disassembler(DisassembleMode.Bit32);

        internal static IntPtr EmulateHandle()
        {
            return (IntPtr)0;
        }

        private static void CodeHookCallback(
            CapstoneDisassembler<X86Instruction, X86Register, X86InstructionGroup, X86InstructionDetail> disassembler,
            Unicorn u,
            long addr,
            int size,
            object userData)
        {
            Console.Write("[+] 0x{0}: ", addr.ToString("X"));

            var eipBuffer = new byte[4];
            u.RegRead(X86.UC_X86_REG_EIP, eipBuffer);

            var effectiveSize = Math.Min(16, size);
            var tmp = new byte[effectiveSize];
            u.MemRead(addr, tmp);

            var sb = new StringBuilder();
            foreach (var t in tmp)
            {
                sb.AppendFormat("{0} ", (0xFF & t).ToString("X"));
            }
            Console.Write("{0,-20}", sb);
            Console.WriteLine(Utils.Disassemble(disassembler, tmp));
        }

        private static void SyscallHookCallback(Unicorn u, object userData)
        {
            var eaxBuffer = new byte[4];
            u.RegRead(X86.UC_X86_REG_EAX, eaxBuffer);
            var eax = Utils.ToInt(eaxBuffer);

            Console.WriteLine("[!] Syscall EAX = 0x{0}", eax.ToString("X"));

            u.EmuStop();
        }

        private static void InterruptHookCallback(Unicorn u, int intNumber, object userData)
        {
            // only handle Linux syscall
            if (intNumber != 0x80)
            {
                return;
            }

            var eaxBuffer = new byte[4];
            var eipBuffer = new byte[4];

            u.RegRead(X86.UC_X86_REG_EAX, eaxBuffer);
            u.RegRead(X86.UC_X86_REG_EIP, eipBuffer);

            var eax = Utils.ToInt(eaxBuffer);
            var eip = Utils.ToInt(eipBuffer);

            switch (eax)
            {
                default:
                    Console.WriteLine("[!] Interrupt 0x{0} num {1}, EAX=0x{2}", eip.ToString("X"), intNumber.ToString("X"), eax.ToString("X"));
                    break;
                case 1: // sys_exit
                    Console.WriteLine("[!] Interrupt 0x{0} num {1}, SYS_EXIT", eip.ToString("X"), intNumber.ToString("X"));
                    u.EmuStop();
                    break;
                case 4: // sys_write

                    // ECX = buffer address
                    var ecxBuffer = new byte[4];

                    // EDX = buffer size
                    var edxBuffer = new byte[4];

                    u.RegRead(X86.UC_X86_REG_ECX, ecxBuffer);
                    u.RegRead(X86.UC_X86_REG_EDX, edxBuffer);

                    var ecx = Utils.ToInt(ecxBuffer);
                    var edx = Utils.ToInt(edxBuffer);

                    // read the buffer in
                    var size = Math.Min(256, edx);
                    var buffer = new byte[size];
                    u.MemRead(ecx, buffer);
                    var content = Encoding.Default.GetString(buffer);

                    Console.WriteLine(
                        "[!] Interrupt 0x{0}: num {1}, SYS_WRITE. buffer = 0x{2}, size = , content = '{3}'",
                        eip.ToString("X"),
                        ecx.ToString("X"),
                        edx.ToString("X"),
                        content);

                    break;
            }
        }
    }
}
