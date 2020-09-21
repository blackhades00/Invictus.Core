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
            return Utils.ReadBool(this.aiManagerInstance + Offsets.AIManager.IsMoving);
        }

        /// <summary>
        /// Returns True if the object is dashing.
        /// </summary>
        /// <param name="objectPtr"></param>
        /// <returns></returns>
        internal bool IsDashing()
        {
            return Utils.ReadBool(this.aiManagerInstance + Offsets.AIManager.IsDashing);
        }

        internal float Velocity()
        {
            return Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.OVelocity);
        }

        /// <summary>
        /// Returns the beginning of a waypoint-path
        /// </summary>
        /// <returns></returns>
        internal Vector3 GetNavBegin()
        {
            float x = Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.NavBegin);
            float y = Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.NavBegin + 4);
            float z = Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.NavBegin + 8);

            return new Vector3(x,y,z);
        }

        /// <summary>
        /// Returns the end of a waypoint-path
        /// </summary>
        /// <returns></returns>
        internal Vector3 GetNavEnd()
        {
            float x = Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.NavEnd);
            float y = Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.NavEnd + 4);
            float z = Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.NavEnd + 8);

            return new Vector3(x,y,z);
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
            float x = Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.TargetPos);
            float y = Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.TargetPos + 4);
            float z = Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.TargetPos + 8);

            return new Vector3(x,y,z);
        }

        /// <summary>
        /// Returns the ServerPosition of the object
        /// </summary>
        /// <returns></returns>
        internal Vector3 GetServerPos()
        {
            float x = Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.ServerPosition);
            float y = Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.ServerPosition + 4);
            float z = Utils.ReadFloat(this.aiManagerInstance + Offsets.AIManager.ServerPosition + 8);

            return new Vector3(x,y,z);
        }
    }
}
