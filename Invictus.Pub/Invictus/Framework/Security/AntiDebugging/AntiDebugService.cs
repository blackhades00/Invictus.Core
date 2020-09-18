// <copyright file="AntiDebugService.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.Security.AntiDebugging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using global::Invictus.Pub.Modules;

namespace Invictus.Pub.Invictus.Framework.Security
{
    /// <summary>
    /// Class which contains all security features such as Runtime Debugger Detection, Debugger attachment Detection, VM Detection, Riot Spy detection etc.
    /// </summary>
    public class AntiDebugService
    {
        internal static Thread AntiDebugServiceThread;
        internal static Thread AntiDumpThread;

        private static readonly List<string> DebuggerList = new List<string>() { "OLLYDBG", "cheatengine-x86_64", "ReClassEx", "ReClassEx64", "x64dbg", "x32dbg", "IDA Pro", "Immunity Debugger", "Ghidra", "de4dot", "de4dot-x64", "ida", "ida64", "dotPeek64", "dotPeek32", "Fiddler", "dnSpy", "dnSpy-x86", "dnSpy.Console" };
        private static readonly List<string> DebuggerWindowHandleList = new List<string>() { "Cheat EngineStruct", "IDA", "IDA -", "JetBrains dotPeek", "OllyDbg", "x64dbg", "x32dbg", "Progress Telerik Fiddler", "dnSpy" };

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

        private static bool IsVM()
        {
            using (var searcher = new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
            {
                using (var items = searcher.Get())
                {
                    foreach (var item in items)
                    {
                        string manufacturer = item["Manufacturer"].ToString().ToLower();
                        if ((manufacturer == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL"))
                            || manufacturer.Contains("vmware")
                            || item["Model"].ToString() == "VirtualBox"
                            || manufacturer.Contains("Hyper")
                            || manufacturer.Contains("Xen")
                            || manufacturer.Contains("VM")
                            || manufacturer.Contains("Virtual")
                            || manufacturer.Contains("QEMU")
                            || manufacturer.Contains("Proxmox")
                            || manufacturer.Contains("Boot Camp")
                            || manufacturer.Contains("Parallels")
                            || manufacturer.Contains("Gnome"))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static bool debuggerPresent = false;

        private static void CheckForDebugger()
        {
            IntPtr pROCESS_HANDLE = Process.GetCurrentProcess().Handle;
            bool isRemoteDebuggerPresent = false;
            NativeImport.CheckRemoteDebuggerPresent(pROCESS_HANDLE, ref isRemoteDebuggerPresent);
            if (NativeImport.IsDebuggerPresent() || isRemoteDebuggerPresent || CheckProcessNamesForDebugger() || IsDebuggerRunningHWND() || IsRiotSpy()
                || CheckDebuggerManagedPresent() || CheckRemoteDebugger() || CheckDebuggerUnmanagedPresent() || CheckDebugPort() ||  IsVM())
            {
                debuggerPresent = true;
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
            Ntstatus.NtStatus status;
            IntPtr debugPort = new IntPtr(0);
            int returnLength;

            unsafe
            {
                status = NativeImport.NtQueryInformationProcess(System.Diagnostics.Process.GetCurrentProcess().Handle, WinStructs.Processinfoclass.ProcessDebugPort, out debugPort, Marshal.SizeOf(debugPort), out returnLength);

                if (status == Ntstatus.NtStatus.Success)
                {
                    if (debugPort == new IntPtr(-1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        [DllImport("ntdll.dll")]
        internal static extern Ntstatus.NtStatus NtSetInformationThread(IntPtr ThreadHandle, WinStructs.ThreadInformationClass ThreadInformationClass, IntPtr ThreadInformation, int ThreadInformationLength);

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(WinStructs.ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);

        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool CloseHandle(IntPtr handle);

        private static bool HideFromDebugger(IntPtr Handle)
        {
            Ntstatus.NtStatus nStatus = NtSetInformationThread(Handle, WinStructs.ThreadInformationClass.ThreadHideFromDebugger, IntPtr.Zero, 0);

            if (nStatus == Ntstatus.NtStatus.Success)
            {
                return true;
            }

            return false;
        }

       

        private static bool DetachFromDebuggerProcess()
        {
            IntPtr hDebugObject = INVALID_HANDLE_VALUE;
            var dwFlags = 0U;
            Ntstatus.NtStatus ntStatus;
            int retLength_1;
            int retLength_2;

            unsafe
            {
                ntStatus = NativeImport.NtQueryInformationProcess(System.Diagnostics.Process.GetCurrentProcess().Handle,WinStructs.Processinfoclass.ProcessDebugObjectHandle, out hDebugObject, IntPtr.Size, out retLength_1);

                if (ntStatus != Ntstatus.NtStatus.Success)
                {
                    return false;
                }

                ntStatus = NativeImport.NtSetInformationDebugObject(hDebugObject, WinStructs.DebugObjectInformationClass.DebugObjectFlags, new IntPtr(&dwFlags), Marshal.SizeOf(dwFlags), out retLength_2);

                if (ntStatus != Ntstatus.NtStatus.Success)
                {
                    return false;
                }

                ntStatus = NativeImport.NtRemoveProcessDebug(System.Diagnostics.Process.GetCurrentProcess().Handle, hDebugObject);

                if (ntStatus != Ntstatus.NtStatus.Success)
                {
                    return false;
                }

                ntStatus = NativeImport.NtClose(hDebugObject);

                if (ntStatus != Ntstatus.NtStatus.Success)
                {
                    return false;
                }
            }

            return true;
        }

     
    }
}