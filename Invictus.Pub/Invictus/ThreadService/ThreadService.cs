// <copyright file="ThreadService.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.ThreadService
{
    using System.Threading;
    using global::Invictus.Core.Invictus.Hacks.TargetSelector;
    using global::Invictus.Pub.Invictus.Hacks;

    internal class ThreadService
    {
        private static Thread thread;
        private static Thread staticListThread;

        internal static void LoadMainThread()
        {
            thread = new Thread(new ThreadStart(MainThread.MainLoop));
            thread.IsBackground = true;
            thread.Start();
        }

    }
}
