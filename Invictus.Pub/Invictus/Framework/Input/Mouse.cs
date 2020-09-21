// <copyright file="Mouse.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

namespace Invictus.Core.Invictus.Framework.Input
{
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    internal class Mouse
    {
        private const uint MouseeventfLeftdown = 0x02;
        private const uint MouseeventfLeftup = 0x04;
        private const uint MouseeventfRightdown = 0x08;
        private const uint MouseeventfRightup = 0x10;
        private const int MouseeventfMove = 0x0001;
        private const int MouseeventfAbsolute = 0x8000;

        public static void MoveTo(int x, int y)
        {
            NativeImport.mouse_event(MouseeventfAbsolute | MouseeventfMove, (uint) x, (uint) y, 0, 0);
        }

        [DllImport("Invictus.ACD.dll")]
        private static extern void IssueAttack(int x, int y);

        internal static void MouseMove(int x, int y)
        {
            IssueAttack(x, y);
        }

        internal static void MouseMoveRelative(int xOffset, int yOffset)
        {
            NativeImport.SetCursorPos(Cursor.Position.X + xOffset, Cursor.Position.Y + yOffset);
        }

        private static void MouseEvent(uint mouseEvent, uint x, uint y)
        {
            NativeImport.mouse_event(mouseEvent, x, y, 0, 0);
        }

        /// <summary>
        /// Holds down the mouse left button.
        /// </summary>
        internal static void MouseLeftDown()
        {
            MouseEvent(MouseeventfLeftdown, (uint) Cursor.Position.X, (uint) Cursor.Position.Y);
        }

        /// <summary>
        /// Releases the mouse left button.
        /// </summary>
        internal static void MouseLeftUp()
        {
            MouseEvent(MouseeventfLeftup, (uint) Cursor.Position.X, (uint) Cursor.Position.Y);
        }

        /// <summary>
        /// Performs a mouse left click.
        /// </summary>
        internal static void MouseClickLeft()
        {
            MouseLeftDown();
            MouseLeftUp();
        }

        /// <summary>
        /// Holds down the mouse right button.
        /// </summary>
        internal static void MouseRightDown()
        {
            MouseEvent(MouseeventfRightdown, (uint) Cursor.Position.X, (uint) Cursor.Position.Y);
        }

        /// <summary>
        /// Releases the mouse right button.
        /// </summary>
        internal static void MouseRightUp()
        {
            MouseEvent(MouseeventfRightup, (uint) Cursor.Position.X, (uint) Cursor.Position.Y);
        }

        /// <summary>
        /// Performs a mouse right click.
        /// </summary>
        internal static void MouseClickRight()
        {
            MouseRightDown();
            MouseRightUp();
        }
    }
}