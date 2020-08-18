﻿// <copyright file="Utils.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;
    using DeviceId;
    using DeviceId.Encoders;
    using DeviceId.Formatters;
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

        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder buff = new StringBuilder(nChars);
            IntPtr handle = NativeImport.GetForegroundWindow();

            if (NativeImport.GetWindowText(handle, buff, nChars) > 0)
            {
                return buff.ToString();
            }

            return String.Empty;
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

        public static bool IsGameInForeground()
        {
            return GetActiveWindowTitle() == "League of Legends (TM) Client";
        }

        public static T Read<T>(int Address)
        {
            var Size = Marshal.SizeOf<T>();
            var Buffer = new byte[Size];
            bool Result = Offsets.ReadProcessMemory(Offsets.PROCESS_HANDLE, (IntPtr)Address, Buffer, Size, out var lpRead);
            var Ptr = Marshal.AllocHGlobal(Size);
            Marshal.Copy(Buffer, 0, Ptr, Size);
            var Struct = Marshal.PtrToStructure<T>(Ptr);
            Marshal.FreeHGlobal(Ptr);
            return Struct;
        }

        internal static int ReadInt(int addr)
        {
            var buffer = new byte[4];
            IntPtr output = IntPtr.Zero;
            Offsets.ReadProcessMemory(Offsets.PROCESS_HANDLE, (IntPtr)addr, buffer, buffer.Length, out output);

            return BitConverter.ToInt32(buffer, 0);
        }

        internal static string ReadString(int address, Encoding Encoding)
        {
            byte[] dataBuffer = new byte[512];
            IntPtr bytesRead = IntPtr.Zero;

            Offsets.ReadProcessMemory(System.Diagnostics.Process.GetProcessesByName("League of Legends").FirstOrDefault().Handle, (IntPtr)address, dataBuffer, dataBuffer.Length, out bytesRead);

            if (bytesRead == IntPtr.Zero)
            {
                return string.Empty;
            }

            return Encoding.GetString(dataBuffer).Split('\0')[0];
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

    }
}