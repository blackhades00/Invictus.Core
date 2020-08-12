// <copyright file="AntiDebugService.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Framework.Security
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using global::Invictus.Pub.Modules;
    using SKM.V3.Methods;
    using SKM.V3.Models;

    public class AntiDebugService
    {
        public static Thread AntiDebugServiceThread;

        private static readonly List<string> DebuggerList = new List<string>() { "OLLYDBG", "cheatengine-x86_64", "ReClassEx", "ReClassEx64", "x64dbg", "x32dbg", "IDA Pro", "Immunity Debugger", "Ghidra", "de4dot", "de4dot-x64", "ida", "ida64", "dotPeek64", "dotPeek32", "Fiddler", "dnSpy", "dnSpy-x86", "dnSpy.Console" };
        private static readonly List<string> DebuggerWindowHandleList = new List<string>() { "Cheat Engine", "IDA", "IDA -", "JetBrains dotPeek", "OllyDbg", "x64dbg", "x32dbg", "Progress Telerik Fiddler", "dnSpy" };

        private static bool CheckProcessNamesForDebugger()
        {
            if (DebuggerList.Intersect(ProcessManager.EnumerateAllProcesses()).Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Test()
        {
            MessageBox.Show("TEST");
        }

        private static bool IsDebuggerRunningHWND()
        {
            bool checkFlag = false;

            foreach (string hWND in ProcessManager.EnumerateWindow())
            {
                checkFlag |= DebuggerWindowHandleList.Any(hWND.Contains) || DebuggerWindowHandleList.ConvertAll(d => d.ToLower()).Any(hWND.Contains);
            }

            return checkFlag;
        }

        private static void CheckForDebugger()
        {
            IntPtr pROCESS_HANDLE = Process.GetCurrentProcess().Handle;
            bool isRemoteDebuggerPresent = false;
            NativeImport.CheckRemoteDebuggerPresent(pROCESS_HANDLE, ref isRemoteDebuggerPresent);
            if (NativeImport.IsDebuggerPresent() || isRemoteDebuggerPresent || CheckProcessNamesForDebugger() || IsDebuggerRunningHWND() || Helpers.IsVM())
            {
                Environment.Exit(1); // If Debugger found, close Invictus.
                AntiDebugServiceThread.Abort();
            }
        }

        public static void StartAntiDbgService()
        {
            AntiDebugServiceThread = new Thread(new ThreadStart(LoadDebugger));
            AntiDebugServiceThread.IsBackground = true;
            AntiDebugServiceThread.Start();
        }

        internal static void LoadDebugger()
        {
            while (true)
            {
                CheckForDebugger();
            }
        }
    }
}
