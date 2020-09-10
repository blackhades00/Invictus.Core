// <copyright file="AIManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;

namespace Invictus.Core.Invictus.Structures.AI_Manager
{
    class AiManager
    {
        private static int GetAiManger(int objectPtr)
        {
            return Utils.DeobfuscateMember(objectPtr + Offsets.AIManager.OAiManager);
        }

        internal static bool IsMoving(int objectPtr)
        {
            var aiManager = GetAiManger(objectPtr);
           return Utils.ReadBool( aiManager + Offsets.AIManager.OAiManagerIsMoving);
        }

        internal static bool IsDashing(int objectPtr)
        {
            var aiManager = GetAiManger(objectPtr);
            return Utils.ReadBool(aiManager + Offsets.AIManager.OAiManagerIsDashing);
        }

    }
}
