// <copyright file="ThreadService.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.ThreadService
{
    using System.Threading;
    using global::Invictus.Pub.Invictus.Framework.Security;
    using global::Invictus.Pub.Invictus.Hacks;

    internal class ThreadService
    {
        private static Thread thread;
       

        internal static void LoadMainThread()
        {
           
            thread = new Thread(new ThreadStart(MainThread.LoadThread));
            thread.IsBackground = true;
            thread.Start();
        }

      
    }
}
