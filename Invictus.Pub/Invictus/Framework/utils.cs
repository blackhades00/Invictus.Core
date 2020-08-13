// <copyright file="Utils.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;
    using DeviceId;
    using DeviceId.Encoders;
    using DeviceId.Formatters;
    using Gee.External.Capstone;
    using Gee.External.Capstone.X86;
    using global::Invictus.Pub.Modules;
    using SharpDX;

    public static class Utils
    {
        internal static void Unload()
        {
            if(Utils.IsKeyPressed(Keys.F12))
            {
                var result = MessageBox.Show("Do you want to exit?", "Exit",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Information);

                if(result == DialogResult.Yes)
                {
                    Environment.Exit(1);
                }
                else
                {
                    // do nothing
                }
            }
        }

        public static string GetUniqueIdentifier()
        {
            DeviceIdBuilder deviceID = new DeviceIdBuilder();
            deviceID.AddMacAddress(true, true);
            deviceID.AddMachineName();
            deviceID.AddMotherboardSerialNumber();
            deviceID.AddOSInstallationID();
            deviceID.AddProcessorId();
            deviceID.AddSystemDriveSerialNumber();
            deviceID.AddSystemUUID();
            deviceID.UseFormatter(new HashDeviceIdFormatter(() => SHA512.Create(), new Base64UrlByteArrayEncoder()));

            return deviceID.ToString();
        }

        internal static long ToInt(byte[] val)
        {
            ulong res = 0;
            for (var i = 0; i < val.Length; i++)
            {
                var v = val[i] & 0xFF;
                res += (ulong)(v << (i * 8));
            }
            return (long)res;
        }

        internal static byte[] Int64ToBytes(long intVal)
        {
            var res = new byte[8];
            var uval = (ulong)intVal;
            for (var i = 0; i < res.Length; i++)
            {
                res[i] = (byte)(uval & 0xff);
                uval = uval >> 8;
            }
            return res;
        }

        internal static string Disassemble(CapstoneDisassembler<X86Instruction, X86Register, X86InstructionGroup, X86InstructionDetail> disassembler, byte[] code)
        {
            var sb = new StringBuilder();
            var instructions = disassembler.DisassembleAll(code);
            foreach (var instruction in instructions)
            {
                sb.AppendFormat("{0} {1}{2}", instruction.Mnemonic, instruction.Operand, Environment.NewLine);
            }
            return sb.ToString().Trim();
        }

        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder buff = new StringBuilder(nChars);
            IntPtr handle = NativeImport.GetForegroundWindow();

            if (NativeImport.GetWindowText(handle, buff, nChars) > 0)
            {
                return buff.ToString();
            }
            return null;
        }

        internal static bool IsKeyPressed(System.Windows.Forms.Keys keys)
        {
            return (NativeImport.GetAsyncKeyState((int)keys) & 0x8000) != 0;
        }

        internal static bool IsControlPressed()
        {
            return (NativeImport.GetAsyncKeyState((int)0x11) & 0x8000) != 0;
        }

        internal static bool IsShiftPressed()
        {
            return (NativeImport.GetAsyncKeyState((int)0x10) & 0x8000) != 0;
        }

        internal static bool IsGameInForeground()
        {
            return GetActiveWindowTitle() == "League of Legends (TM) Client";
        }

        internal static int ReadInt(int addr)
        {
            var buffer = new byte[4];
            IntPtr output = IntPtr.Zero;
            Offsets.ReadProcessMemory(Offsets.PROCESS_HANDLE, (IntPtr)addr, buffer, buffer.Length, out output);

            return BitConverter.ToInt32(buffer, 0);
        }

        internal static float ReadFloat(int addr)
        {
            var buffer = new byte[4];
            IntPtr output = IntPtr.Zero;
            Offsets.ReadProcessMemory(Offsets.PROCESS_HANDLE, (IntPtr)addr, buffer, buffer.Length, out output);

            return BitConverter.ToSingle(buffer, 0);
        }

        internal static uint ReadUInt(int addr)
        {
            var buffer = new byte[4];
            IntPtr output = IntPtr.Zero;
            Offsets.ReadProcessMemory(Offsets.PROCESS_HANDLE, (IntPtr)addr, buffer, buffer.Length, out output);

            return BitConverter.ToUInt32(buffer, 0);
        }

        internal static Matrix ReadMatrix(int address)
        {
            Matrix tmp = Matrix.Zero;

            byte[] buffer = new byte[64];
            IntPtr byteRead;

            Offsets.ReadProcessMemory(System.Diagnostics.Process.GetProcessesByName("League of Legends").FirstOrDefault().Handle, (IntPtr)address, buffer, 64, out byteRead);

            if (byteRead == IntPtr.Zero)
            {
                Console.WriteLine($"[ReadMatrix] No bytes has been read at 0x{address.ToString("X")}");
                return new Matrix();
            }

            tmp.M11 = BitConverter.ToSingle(buffer, 0 * 4);
            tmp.M12 = BitConverter.ToSingle(buffer, 1 * 4);
            tmp.M13 = BitConverter.ToSingle(buffer, 2 * 4);
            tmp.M14 = BitConverter.ToSingle(buffer, 3 * 4);

            tmp.M21 = BitConverter.ToSingle(buffer, 4 * 4);
            tmp.M22 = BitConverter.ToSingle(buffer, 5 * 4);
            tmp.M23 = BitConverter.ToSingle(buffer, 6 * 4);
            tmp.M24 = BitConverter.ToSingle(buffer, 7 * 4);

            tmp.M31 = BitConverter.ToSingle(buffer, 8 * 4);
            tmp.M32 = BitConverter.ToSingle(buffer, 9 * 4);
            tmp.M33 = BitConverter.ToSingle(buffer, 10 * 4);
            tmp.M34 = BitConverter.ToSingle(buffer, 11 * 4);

            tmp.M41 = BitConverter.ToSingle(buffer, 12 * 4);
            tmp.M42 = BitConverter.ToSingle(buffer, 13 * 4);
            tmp.M43 = BitConverter.ToSingle(buffer, 14 * 4);
            tmp.M44 = BitConverter.ToSingle(buffer, 15 * 4);

            return tmp;
        }

        internal static T Read<T>(IntPtr address)
        {
            var size = Marshal.SizeOf<T>();
            var buffer = new byte[size];
            bool result = Offsets.ReadProcessMemory(System.Diagnostics.Process.GetProcessesByName("League of Legends").FirstOrDefault().Handle, address, buffer, size, out var lpRead);
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(buffer, 0, ptr, size);
            var @struct = Marshal.PtrToStructure<T>(ptr);
            Marshal.FreeHGlobal(ptr);
            return @struct;
        }
    }
}