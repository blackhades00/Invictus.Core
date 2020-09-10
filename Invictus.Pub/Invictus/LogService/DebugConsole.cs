// <copyright file="DebugConsole.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Runtime.InteropServices;

namespace Invictus.Core.Invictus.LogService
{
    internal static class DebugConsole
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool AllocConsole();

        internal static void PrintDbgMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        internal static void PrintErrorMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
