// <copyright file="AntiDebugService.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Framework.Security
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using global::Invictus.Core.Invictus.Framework.Security.AntiDebugging;
    using global::Invictus.Pub.Modules;
    using SKM.V3.Methods;
    using SKM.V3.Models;
    using static global::Invictus.Core.Invictus.Framework.Security.AntiDebugging.NTSTATUS;
    using static global::Invictus.Core.Invictus.Framework.Security.AntiDebugging.WinStructs;

    public class AntiDebugService
    {
        internal static Thread AntiDebugServiceThread;
        internal static Thread AntiDumpThread;

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

        private static bool IsRiotSpy()
        {
            string computerName = Environment.MachineName;
            if (computerName.Contains("riot") || computerName.Contains("Riot") || computerName.Contains("Rito") || computerName.Contains("Anticheat") || computerName.Contains("Mirage"))
            {
                return true;
            }

            return false;
        }

        private static void CheckForDebugger()
        {
            IntPtr pROCESS_HANDLE = Process.GetCurrentProcess().Handle;
            bool isRemoteDebuggerPresent = false;
            NativeImport.CheckRemoteDebuggerPresent(pROCESS_HANDLE, ref isRemoteDebuggerPresent);
            if (NativeImport.IsDebuggerPresent() || isRemoteDebuggerPresent || CheckProcessNamesForDebugger() || IsDebuggerRunningHWND() || IsRiotSpy()
                || CheckDebuggerManagedPresent() || CheckRemoteDebugger() || CheckDebuggerUnmanagedPresent() || CheckDebugPort() || CheckKernelDebugInformation())
            {
                DetachFromDebuggerProcess();
                Environment.Exit(1); // If Debugger found, close Invictus.
                AntiDebugServiceThread.Abort();
            }
        }

        public static void StartAntiDbgService()
        {
            AntiDebugServiceThread = new Thread(new ThreadStart(LoadAntiDebugger));
            AntiDebugServiceThread.IsBackground = true;
            AntiDebugServiceThread.Start();
        }

        internal static void LoadAntiDebugger()
        {
            while (true)
            {
                CheckForDebugger();
                HideOSThreads(); // Hide from Debugger attachlist
            }
        }



        /// <summary>
        /// Asks the CLR for the presence of an attached managed debugger, and never even bothers to check for the presence of a native debugger.
        /// </summary>
        private static bool CheckDebuggerManagedPresent()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Asks the kernel for the presence of an attached native debugger, and has no knowledge of managed debuggers.
        /// </summary>
        private static bool CheckDebuggerUnmanagedPresent()
        {
            if (NativeImport.IsDebuggerPresent())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks whether a process is being debugged.
        /// </summary>
        /// <remarks>
        /// The "remote" in CheckRemoteDebuggerPresent does not imply that the debugger
        /// necessarily resides on a different computer; instead, it indicates that the 
        /// debugger resides in a separate and parallel process.
        /// </remarks>
        private static bool CheckRemoteDebugger()
        {
            var isDebuggerPresent = (bool)false;

            var bApiRet = NativeImport.CheckRemoteDebuggerPresent(System.Diagnostics.Process.GetCurrentProcess().Handle, ref isDebuggerPresent);

            if (bApiRet && isDebuggerPresent)
            {
                return true;
            }

            return false;
        }

        static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        private static bool CheckDebugPort()
        {
            NtStatus status;
            IntPtr DebugPort = new IntPtr(0);
            int ReturnLength;

            unsafe
            {
                status = NativeImport.NtQueryInformationProcess(System.Diagnostics.Process.GetCurrentProcess().Handle, PROCESSINFOCLASS.ProcessDebugPort, out DebugPort, Marshal.SizeOf(DebugPort), out ReturnLength);

                if (status == NtStatus.Success)
                {
                    if (DebugPort == new IntPtr(-1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        [DllImport("ntdll.dll")]
        internal static extern NtStatus NtSetInformationThread(IntPtr ThreadHandle, ThreadInformationClass ThreadInformationClass, IntPtr ThreadInformation, int ThreadInformationLength);

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);

        private static bool HideFromDebugger(IntPtr Handle)
        {
            NtStatus nStatus = NtSetInformationThread(Handle, ThreadInformationClass.ThreadHideFromDebugger, IntPtr.Zero, 0);

            if (nStatus == NtStatus.Success)
            {
                return true;
            }

            return false;
        }

        internal static void HideOSThreads()
        {
            ProcessThreadCollection currentThreads = Process.GetCurrentProcess().Threads;

            foreach (ProcessThread thread in currentThreads)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[GetOSThreads]: thread.Id {0:X}", thread.Id);

                IntPtr pOpenThread = OpenThread(ThreadAccess.SET_INFORMATION, false, (uint)thread.Id);

                if (pOpenThread == IntPtr.Zero)
                {                    continue;
                }

                HideFromDebugger(pOpenThread);
              
                CloseHandle(pOpenThread);
            }
        }

        private static bool DetachFromDebuggerProcess()
        {
            IntPtr hDebugObject = INVALID_HANDLE_VALUE;
            var dwFlags = 0U;
            NtStatus ntStatus;
            int retLength_1;
            int retLength_2;

            unsafe
            {
                ntStatus = NativeImport.NtQueryInformationProcess(System.Diagnostics.Process.GetCurrentProcess().Handle, PROCESSINFOCLASS.ProcessDebugObjectHandle, out hDebugObject, IntPtr.Size, out retLength_1);

                if (ntStatus != NtStatus.Success)
                {
                    return false;
                }

                ntStatus = NativeImport.NtSetInformationDebugObject(hDebugObject, DebugObjectInformationClass.DebugObjectFlags, new IntPtr(&dwFlags), Marshal.SizeOf(dwFlags), out retLength_2);

                if (ntStatus != NtStatus.Success)
                {
                    return false;
                }

                ntStatus = NativeImport.NtRemoveProcessDebug(System.Diagnostics.Process.GetCurrentProcess().Handle, hDebugObject);

                if (ntStatus != NtStatus.Success)
                {
                    return false;
                }

                ntStatus = NativeImport.NtClose(hDebugObject);

                if (ntStatus != NtStatus.Success)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckKernelDebugInformation()
        {
            SYSTEM_KERNEL_DEBUGGER_INFORMATION pSKDI;

            int retLength;
            NtStatus ntStatus;

            unsafe
            {
                ntStatus = NativeImport.NtQuerySystemInformation(SYSTEM_INFORMATION_CLASS.SystemKernelDebuggerInformation, new IntPtr(&pSKDI), Marshal.SizeOf(pSKDI), out retLength);

                if (ntStatus == NtStatus.Success)
                {
                    if (pSKDI.KernelDebuggerEnabled && !pSKDI.KernelDebuggerNotPresent)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
