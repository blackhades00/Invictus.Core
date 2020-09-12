// <copyright file="AIManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;

namespace Invictus.Core.Invictus.Structures.AI_Manager
{
    /// <summary>
    /// AI Manager class is an Instance of the so called "AI Manager", used to check current "states" of the object (moving, dashing etc).
    /// </summary>
   internal static class AiManager
    {
        /// <summary>
        /// Returns an instance of the AI Manager
        /// </summary>
        /// <param name="objectPtr"></param>
        /// <returns></returns>
        private static int GetAiManger(int objectPtr)
        {
            return Utils.DeobfuscateMember(objectPtr + Offsets.AIManager.OAiManager);
        }

        /// <summary>
        /// Returns True if the object is moving.
        /// </summary>
        /// <param name="objectPtr"></param>
        /// <returns></returns>
        internal static bool IsMoving(this int  objectPtr)
        {
            var aiManager = GetAiManger(objectPtr);
           return Utils.ReadBool( aiManager + Offsets.AIManager.OAiManagerIsMoving);
        }

        /// <summary>
        /// Returns True if the object is dashing.
        /// </summary>
        /// <param name="objectPtr"></param>
        /// <returns></returns>
        internal static bool IsDashing(this int objectPtr)
        {
            var aiManager = GetAiManger(objectPtr);
            return Utils.ReadBool(aiManager + Offsets.AIManager.OAiManagerIsDashing);
        }

    }
}
