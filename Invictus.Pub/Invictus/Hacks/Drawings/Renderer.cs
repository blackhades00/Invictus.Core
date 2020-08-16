// <copyright file="Renderer.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Pub.Invictus.Drawings
{
    using SharpDX;

    internal class Renderer
    {
        private const int Width = 0x0014;
        private const int Height = Width + 0x4;

        // B9 ? ? ? ? E8 ? ? ? ? B9 ? ? ? ? E9 ? ? ? ?
        // ZoomClass + 0 = ViewMatrix
        private static readonly int ViewMatrix = Offsets.BASE + Offsets.OViewMatrix;
        private static readonly int ProjectionMatrix = ViewMatrix + 0x40;

        internal static int Instance { get; } = Utils.ReadInt(Offsets.BASE + Offsets.ORenderer);

        /// <summary>
        /// Gets ViewProjection Matrix.
        /// </summary>
        /// <returns></returns>
        internal static Matrix GetViewProjectionMatrix()
        {
            return Matrix.Multiply(GetViewMatrix(), GetProjectionMatrix());
        }

        /// <summary>
        /// Gets View Matrix.
        /// </summary>
        /// <returns></returns>
        internal static Matrix GetViewMatrix()
        {
            return Utils.ReadMatrix(ViewMatrix);
        }

        /// <summary>
        /// Gets Projection Matrix.
        /// </summary>
        /// <returns></returns>
        internal static Matrix GetProjectionMatrix()
        {
            return Utils.ReadMatrix(ProjectionMatrix);
        }

        /// <summary>
        /// Gets Screen Resolution - Width and Height.
        /// </summary>
        /// <returns></returns>
        internal static Vector2 GetScreenResolution()
        {
            return new Vector2() { X = Utils.ReadInt(Instance + Width), Y = Utils.ReadInt(Instance + Height) };
        }

        /// <summary>
        /// Transforms Vector3 World Position to Vector2 Screen Position.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static Vector2 WorldToScreen(Vector3 pos)
        {
            Vector2 returnVec = Vector2.Zero;

            Vector2 screen = GetScreenResolution();
            Matrix matrix = GetViewProjectionMatrix();

            Vector4 clipCoords;
            clipCoords.X = (pos.X * matrix[0]) + (pos.Y * matrix[4]) + (pos.Z * matrix[8]) + matrix[12];
            clipCoords.Y = (pos.X * matrix[1]) + (pos.Y * matrix[5]) + (pos.Z * matrix[9]) + matrix[13];
            clipCoords.Z = (pos.X * matrix[2]) + (pos.Y * matrix[6]) + (pos.Z * matrix[10]) + matrix[14];
            clipCoords.W = (pos.X * matrix[3]) + (pos.Y * matrix[7]) + (pos.Z * matrix[11]) + matrix[15];

            if (clipCoords[3] < 0.1f)
            {
                return returnVec;
            }

            Vector3 m;
            m.X = clipCoords.X / clipCoords.W;
            m.Y = clipCoords.Y / clipCoords.W;
            m.Z = clipCoords.Z / clipCoords.W;

            returnVec.X = (screen.X / 2 * m.X) + (m.X + (screen.X / 2));
            returnVec.Y = -(screen.Y / 2 * m.Y) + (m.Y + (screen.Y / 2));

            return returnVec;
        }
    }
}
