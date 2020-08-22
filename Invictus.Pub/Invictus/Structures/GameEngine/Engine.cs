// <copyright file="Engine.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Core.Invictus.Structures.GameEngine
{
    using System;
    using global::Invictus.Pub.Invictus;
    using global::Invictus.Pub.Invictus.GameEngine.GameObjects;

    class Engine
    {
        internal static float LastAATick = 0;

        internal static float GetGameTime()
        {
            return Utils.ReadFloat(Offsets.BASE + Offsets.oGameTime);
        }

        internal static int GetPing()
        {
            return 30;
        }

        internal static bool CanAttack()
        {
            return Environment.TickCount + GetPing() / 2 + 25 >= LastAATick + GameObject.GetAttackDelay(GameObject.GetLocalPLayer());
        }

        internal static bool CanMove(float extraWindup)
        {
            return Environment.TickCount + GetPing() / 2 >= LastAATick + GameObject.GetAttackCastDelay(GameObject.GetLocalPLayer()) * 1000 + extraWindup;

        }
    }
}
