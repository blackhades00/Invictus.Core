// <copyright file="ProcessManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// ProcessManager class to get the ProcessName of League to obtain the BaseAddress.
    /// </summary>
    internal class ProcessManager
    {
        internal static Process GetProcessString(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                // Process Name Could Not Be Found
                return null;
            }

            return Process.GetProcessesByName(processName).FirstOrDefault();
        }

        internal static Process GetProcessByWindowName(string windowName)
        {
            Process prcs = null;

            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    if (process.MainWindowTitle.Equals(windowName))
                    {
                        prcs = process;
                        break;
                    }
                }
                catch (InvalidOperationException e) { }
            }

            return prcs;
        }

        internal static List<string> EnumerateAllProcesses(int limit = 0)
        {
            List<string> processList = new List<string>();

            if (limit == 0)
            {
                foreach (Process prcs1 in Process.GetProcesses())
                {
                    try
                    {
                        processList.Add(prcs1.ProcessName);
                    }
                    catch (InvalidOperationException e) { }
                }
            }
            else
            {
                foreach (Process prcs in Process.GetProcesses().Take(limit))
                {
                    try
                    {
                        processList.Add(prcs.ProcessName);
                    }
                    catch (InvalidOperationException e) { }
                }
            }

            return processList;
        }

        internal static List<string> EnumerateWindow(int limit = 0)
        {
            List<string> hWNDStorage = new List<string>();

            if (limit == 0)
            {
                foreach (Process process in Process.GetProcesses())
                {
                    try
                    {
                        if (process.MainWindowTitle.Length != 0)
                        {
                            hWNDStorage.Add(process.MainWindowTitle);
                        }
                    }
                    catch (InvalidOperationException e) { }
                }
            }
            else
            {
                foreach (Process process in Process.GetProcesses().Take(limit))
                {
                    try
                    {
                        if (process.MainWindowTitle.Length != 0)
                        {
                            hWNDStorage.Add(process.MainWindowTitle);
                        }
                    }
                    catch (InvalidOperationException e) { }
                }
            }

            return hWNDStorage;
        }
    }
}