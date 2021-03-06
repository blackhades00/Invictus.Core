// <copyright file="Utils.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DeviceId;
using DeviceId.Encoders;
using DeviceId.Formatters;
using InvictusSharp.Framework.UpdateService;
using InvictusSharp.LogService;

using SharpDX;

namespace InvictusSharp.Framework
{
    /// <summary>
    /// The Utils class contains all "Utility" functions such as generating a unique ID using the HWID, Unloading InvictusSharp etc.
    /// </summary>
    public static class Utils
    {
        internal static void Unload()
        {
            if (IsKeyPressed(Keys.F12))
            {
                var result = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Environment.Exit(1);
                }
                else
                {
                    // do nothing
                }
            }
        }

        public static void SetZoom()
        {
            int zoomclass = Utils.ReadInt(Offsets.Base + Offsets.EngineStruct.oZoomClass);
            Utils.Write(zoomclass + 0x28, 4500f);
        }

        /// <summary>
        /// Being called within the Loader.
        /// </summary>
        /// <returns></returns>
        public static string GetUniqueIdentifier()
        {
            var deviceId = new DeviceIdBuilder();
            deviceId.AddMacAddress(true, true);
            deviceId.AddMotherboardSerialNumber();
            deviceId.AddProcessorId();
            deviceId.AddSystemDriveSerialNumber();
            deviceId.AddSystemUUID();
            deviceId.UseFormatter(new HashDeviceIdFormatter(() => SHA512.Create(), new Base64UrlByteArrayEncoder()));

            return deviceId.ToString();
        }

        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            var buff = new StringBuilder(nChars);
            var handle = NativeImport.GetForegroundWindow();

            if (NativeImport.GetWindowText(handle, buff, nChars) > 0) return buff.ToString();

            return string.Empty;
        }

        internal static bool IsKeyPressed(Keys keys)
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

        internal static bool ReadBool(int address)
        {
            var dataBuffer = new byte[4];
            var bytesRead = IntPtr.Zero;


            Offsets.ReadProcessMemory(Offsets.ProcessHandle, (IntPtr)address, dataBuffer, dataBuffer.Length,
                out bytesRead);

            return BitConverter.ToBoolean(dataBuffer, 0);
        }

        internal static int ReadInt(int addr)
        {
            var buffer = new byte[4];
            var output = IntPtr.Zero;
            Offsets.ReadProcessMemory(Offsets.ProcessHandle, (IntPtr)addr, buffer, buffer.Length, out output);

            return BitConverter.ToInt32(buffer, 0);
        }

        internal static string ReadString(int address, Encoding encoding)
        {
            var dataBuffer = new byte[512];
            var bytesRead = IntPtr.Zero;

            Offsets.ReadProcessMemory(Offsets.ProcessHandle, (IntPtr)address, dataBuffer, dataBuffer.Length,
                out bytesRead);


            return encoding.GetString(dataBuffer).Split('\0')[0];
        }

        internal static float ReadFloat(int address)
        {
            var buffer = new byte[4];
            var output = IntPtr.Zero;
            Offsets.ReadProcessMemory(Offsets.ProcessHandle, (IntPtr)address, buffer, buffer.Length, out output);

            return BitConverter.ToSingle(buffer, 0);
        }

        internal static uint ReadUInt(IntPtr addr)
        {
            var buffer = new byte[4];
            var output = IntPtr.Zero;
            Offsets.ReadProcessMemory(Offsets.ProcessHandle, addr, buffer, buffer.Length, out output);

            return BitConverter.ToUInt32(buffer, 0);
        }

        internal static Matrix ReadMatrix(int address)
        {
            var tmp = Matrix.Zero;

            var buffer = new byte[64];
            IntPtr byteRead;

            Offsets.ReadProcessMemory(Offsets.ProcessHandle, (IntPtr)address, buffer, 64, out byteRead);

            if (byteRead == IntPtr.Zero)
            {
                Logger.Log($"[ReadMatrix] No bytes has been read at 0x{address.ToString("X")}",
                    Logger.eLoggerType.Warn);
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

        /// <summary>
        /// Used for Deobfuscation of internal League Functions.
        /// </summary>
        /// <param name="leagueHandle">Handle to League of Legends</param>
        /// <param name="address">Address of the Member u want to deobfuscate.</param>
        /// <returns></returns>
        [DllImport("Invictus.ACD.dll")]
        private static extern int DeobfuscateMember(IntPtr leagueHandle, int address);

        internal static int DeobfuscateMember(int address)
        {
            return DeobfuscateMember(Offsets.ProcessHandle, address);
        }
        /// <summary>
        /// Normalze a vector
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static Vector3 NormalizeVector(this Vector3 vec)
        {
            float length = vec.Length();
            if (length != 0)
            {
                float inv = 1.0f / length;
                vec.X *= inv;
                vec.Y *= inv;
                vec.Z *= inv;
            }
            return new Vector3(vec.X, vec.Y, vec.Z);
        }
        public static float Length(this Vector3 vec)
        {
            return (float)Math.Sqrt((vec.X * vec.X) + (vec.Y * vec.Y) + (vec.Z * vec.Z));
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            Int32 nSize,
            out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [MarshalAs(UnmanagedType.AsAny)] object lpBuffer,
            int dwSize,
            out IntPtr lpNumberOfBytesWritten);
       public static void Write(int Addr, float value)
       {
           var buffer = BitConverter.GetBytes(value);
            var output = IntPtr.Zero;
           WriteProcessMemory(Offsets.ProcessHandle, (IntPtr)Addr, buffer, buffer.Length, out output);
        }

    }
}
