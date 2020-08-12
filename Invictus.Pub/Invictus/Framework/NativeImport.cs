// <copyright file="NativeImport.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Modules
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using global::Invictus.Pub.Invictus.Drawings;

    internal class NativeImport
    {
        [DllImport("kernel32.dll")]
        internal static extern bool IsDebuggerPresent();

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, [MarshalAs(UnmanagedType.Bool)] ref bool isDebuggerPresent);

        internal const int WM_NCLBUTTONDOWN = 0xA1;
        internal const int HTCAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        internal static extern bool ReleaseCapture();

        [DllImportAttribute("user32.dll")]
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
    }
}
