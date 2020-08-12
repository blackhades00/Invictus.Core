// <copyright file="MainThread.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Hacks
{
    internal class MainThread
    {
        internal static void LoadThread()
        {
            while (true)
            {
                Orbwalker.Orbwalker.Orbwalk();
            }
            
        }
    }
}
