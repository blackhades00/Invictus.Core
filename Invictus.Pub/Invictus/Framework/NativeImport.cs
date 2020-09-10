﻿// <copyright file="NativeImport.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using global::Invictus.Core.Invictus.Framework.Security.AntiDebugging;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Invictus.Core.Invictus.Framework.Input;
using Invictus.Core.Invictus.Hacks.Drawings;

namespace Invictus.Core.Invictus.Framework
{
    using static WinStructs;

    internal class NativeImport
    {
        [DllImport("kernel32.dll")]
        internal static extern bool IsDebuggerPresent();

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        internal static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, [MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)] ref bool isDebuggerPresent);

        internal const int WM_NCLBUTTONDOWN = 0xA1;
        internal const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        internal static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll")]
        internal static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("dwmapi.dll")]
        internal static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref DrawFactory.Margins pMargins);

        [DllImport("user32.dll")]
        internal static extern ushort GetAsyncKeyState(int vKey);

        // DEBUG IMPORTS

        [DllImport("ntdll.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern Ntstatus.NtStatus NtQueryInformationProcess([In]
            IntPtr processHandle, [In] Processinfoclass processInformationClass, out IntPtr processInformation, [In] int processInformationLength, [Optional] out int returnLength);

        [DllImport("ntdll.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern Ntstatus.NtStatus NtClose([In]
            IntPtr handle);

        [DllImport("ntdll.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern Ntstatus.NtStatus NtRemoveProcessDebug(IntPtr processHandle, IntPtr debugObjectHandle);

        [DllImport("ntdll.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern Ntstatus.NtStatus NtSetInformationDebugObject([In]
            IntPtr debugObjectHandle, [In] DebugObjectInformationClass debugObjectInformationClass, [In]
            IntPtr debugObjectInformation, [In] int debugObjectInformationLength, [Out] [Optional] out int returnLength);

        [DllImport("ntdll.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern Ntstatus.NtStatus NtQuerySystemInformation([In] SystemInformationClass systemInformationClass, IntPtr systemInformation, [In] int systemInformationLength, [Out] [Optional] out int returnLength);

        [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern System.UInt32 SendInput(System.UInt32 nInputs, [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPArray, SizeConst = 1)] Keyboard.INPUT[] pInputs, System.Int32 cbSize);
    }
}
