// <copyright file="MainThread.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Pub.Invictus.GameEngine.GameObjects;

namespace Invictus.Pub.Invictus.Hacks
{
    internal class MainThread
    {
        internal static void MainLoop()
        {
            while (true)
            {
                Utils.Unload();
                if(Utils.IsGameInForeground() && CGameObject.GetLocalPLayer() != 0)
                {
                    Orbwalker.Orbwalker.Orbwalk();
                }
               
            }
            
        }
    }
}
