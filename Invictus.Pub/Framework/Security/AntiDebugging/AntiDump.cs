// <copyright file="AntiDump.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;

namespace InvictusSharp.Framework.Security.AntiDebugging
{
    /// <summary>
    /// Protects InvictusSharp from being dumped
    /// </summary>
    internal class AntiDump
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern IntPtr VirtualProtect(IntPtr lpAddress, IntPtr dwSize, IntPtr flNewProtect,
            ref IntPtr lpflOldProtect);

        private static void EraseSection(IntPtr address, int size)
        {
            var sz = (IntPtr) size;
            var dwOld = default(IntPtr);
            VirtualProtect(address, sz, (IntPtr) 0x40, ref dwOld);
            ZeroMemory(address, sz);
            var temp = default(IntPtr);
            VirtualProtect(address, sz, dwOld, ref temp);
        }

        /// <summary>
        /// WARNING! It breaks applications which are obfuscated.
        /// </summary>
        internal static void Load()
        {
            var process = System.Diagnostics.Process.GetCurrentProcess();
            var baseAddress = process.MainModule.BaseAddress;
            var dwpeheader = System.Runtime.InteropServices.Marshal.ReadInt32((IntPtr) (baseAddress.ToInt32() + 0x3C));
            var wnumberofsections =
                System.Runtime.InteropServices.Marshal.ReadInt16((IntPtr) (baseAddress.ToInt32() + dwpeheader + 0x6));

            EraseSection(baseAddress, 30);

            for (var i = 0; i < _peheaderdwords.Length; i++)
                EraseSection((IntPtr) (baseAddress.ToInt32() + dwpeheader + _peheaderdwords[i]), 4);

            for (var i = 0; i < _peheaderwords.Length; i++)
                EraseSection((IntPtr) (baseAddress.ToInt32() + dwpeheader + _peheaderwords[i]), 2);

            for (var i = 0; i < _peheaderbytes.Length; i++)
                EraseSection((IntPtr) (baseAddress.ToInt32() + dwpeheader + _peheaderbytes[i]), 1);

            var x = 0;
            var y = 0;

            while (x <= wnumberofsections)
            {
                if (y == 0) EraseSection((IntPtr) (baseAddress.ToInt32() + dwpeheader + 0xFA + 0x28 * x + 0x20), 2);

                EraseSection((IntPtr) (baseAddress.ToInt32() + dwpeheader + 0xFA + 0x28 * x + _sectiontabledwords[y]),
                    4);

                y++;

                if (y == _sectiontabledwords.Length)
                {
                    x++;
                    y = 0;
                }
            }
        }

        private static int[] _sectiontabledwords = new int[] {0x8, 0xC, 0x10, 0x14, 0x18, 0x1C, 0x24};
        private static int[] _peheaderbytes = new int[] {0x1A, 0x1B};

        private static int[] _peheaderwords = new int[]
            {0x4, 0x16, 0x18, 0x40, 0x42, 0x44, 0x46, 0x48, 0x4A, 0x4C, 0x5C, 0x5E};

        private static int[] _peheaderdwords = new int[]
        {
            0x0, 0x8, 0xC, 0x10, 0x16, 0x1C, 0x20, 0x28, 0x2C, 0x34, 0x3C, 0x4C, 0x50, 0x54, 0x58, 0x60, 0x64, 0x68,
            0x6C, 0x70, 0x74, 0x104, 0x108, 0x10C, 0x110, 0x114, 0x11C
        };
    }
}