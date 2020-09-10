// <copyright file="ThreadService.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System.Threading;
using Invictus.Core.Invictus.Hacks;

namespace Invictus.Core.Invictus.ThreadService
{
    internal class ThreadService
    {
        private static Thread _thread;
        private static Thread _staticListThread;

        internal static void LoadMainThread()
        {
            _thread = new Thread(new ThreadStart(MainThread.MainLoop));
            _thread.IsBackground = true;
            _thread.Start();
        }

    }
}
