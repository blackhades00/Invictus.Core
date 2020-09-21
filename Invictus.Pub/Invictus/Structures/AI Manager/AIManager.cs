// <copyright file="AiManager.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using Invictus.Core.Invictus.Framework;
using Invictus.Core.Invictus.Framework.UpdateService;
using SharpDX;

namespace Invictus.Core.Invictus.Structures.AI_Manager
{
    /// <summary>
    /// AI Manager class is an Instance of the so called "AI Manager", used to check current "states" of the object (moving, dashing etc).
    /// </summary>
    internal class AiManager
    {
        /// <summary>
        /// Instance of AI Manager for the given object.
        /// </summary>
        private int aiManagerInstance { get; set; }

        internal AiManager(int aiManagerInstance)
        {
            this.aiManagerInstance = aiManagerInstance;
        }

        /// <summary>
        /// Returns True if the object is moving.
        /// </summary>
        /// <param name="objectPtr"></param>
        /// <returns></returns>
        internal bool IsMoving()
        {
            return Utils.ReadBool(aiManagerInstance + Offsets.AIManager.IsMoving);
        }

        /// <summary>
        /// Returns True if the object is dashing.
        /// </summary>
        /// <param name="objectPtr"></param>
        /// <returns></returns>
        internal bool IsDashing()
        {
            return Utils.ReadBool(aiManagerInstance + Offsets.AIManager.IsDashing);
        }

        internal float Velocity()
        {
            return Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.OVelocity);
        }

        /// <summary>
        /// Returns the beginning of a waypoint-path
        /// </summary>
        /// <returns></returns>
        internal Vector3 GetNavBegin()
        {
            var x = Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.NavBegin);
            var y = Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.NavBegin + 4);
            var z = Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.NavBegin + 8);

            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Returns the end of a waypoint-path
        /// </summary>
        /// <returns></returns>
        internal Vector3 GetNavEnd()
        {
            var x = Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.NavEnd);
            var y = Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.NavEnd + 4);
            var z = Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.NavEnd + 8);

            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Returns the DashSpeed
        /// </summary>
        /// <returns></returns>
        internal float GetDashSpeed()
        {
            return Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.CurrentDashSpeed);
        }

        /// <summary>
        /// Returns the TargetPos
        /// </summary>
        /// <returns></returns>
        internal Vector3 GetTargetPos()
        {
            var x = Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.TargetPos);
            var y = Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.TargetPos + 4);
            var z = Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.TargetPos + 8);

            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Returns the ServerPosition of the object
        /// </summary>
        /// <returns></returns>
        internal Vector3 GetServerPos()
        {
            var x = Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.ServerPosition);
            var y = Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.ServerPosition + 4);
            var z = Utils.ReadFloat(aiManagerInstance + Offsets.AIManager.ServerPosition + 8);

            return new Vector3(x, y, z);
        }
    }
}