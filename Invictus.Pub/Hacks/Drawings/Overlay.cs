// <copyright file="Overlay.cs" company="Invictus">
// Copyright (c) Invictus. All rights reserved.
// </copyright>

using System;
using System.Windows.Forms;
using InvictusSharp.Callbacks;
using InvictusSharp.Framework;
using InvictusSharp.Framework.Menu;
using SharpDX;
using SharpDX.Direct3D9;
using SharpDX.Windows;

namespace InvictusSharp.Hacks.Drawings
{
    public partial class Overlay : Form
    {
        internal static MenuBox MenuBoxView = new MenuBox();

        /// <summary>
        /// Initializes a new instance of the <see cref="Overlay"/> class.
        /// </summary>
        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            // MenuBoxView.Show();
            TopMost = true;
            OnLoad();
        }

        private void Overlay_Paint(object sender, PaintEventArgs e)
        {
            OnPaint();
        }

        internal void StartRenderLoop()
        {
            RenderLoop.Run(this, () =>
            {
                DrawFactory.Device.Clear(ClearFlags.Target, new SharpDX.Mathematics.Interop.RawColorBGRA(0, 0, 0, 0),
                    1.0f, 0);
                DrawFactory.Device.SetRenderState(RenderState.ZEnable, false);
                DrawFactory.Device.SetRenderState(RenderState.Lighting, false);
                DrawFactory.Device.SetRenderState(RenderState.CullMode, Cull.None);
                DrawFactory.Device.SetTransform(TransformState.Projection,
                    Matrix.OrthoOffCenterLH(0, Width, Height, 0, 0, 1));

                DrawFactory.Device.BeginScene();

                OnDraw ondraw_callback = new OnDraw();
                ondraw_callback.LoadCallback();

                DrawFactory.Device.EndScene();
                DrawFactory.Device.Present();
            });
        }

        internal void OnLoad()
        {
            NativeImport.SetWindowLong(Handle, DrawFactory.GWL_EXSTYLE,
                (IntPtr)(NativeImport.GetWindowLong(Handle, DrawFactory.GWL_EXSTYLE) ^ DrawFactory.WS_EX_LAYERED ^
                          DrawFactory.WS_EX_TRANSPARENT));

            NativeImport.SetLayeredWindowAttributes(Handle, 0, 255, DrawFactory.LWA_ALPHA);

            var presentParameters = new PresentParameters
            {
                Windowed = true,
                SwapEffect = SwapEffect.Discard,
                BackBufferFormat = Format.A8R8G8B8
            };

            DrawFactory.Device = new Device(DrawFactory.D3D, 0, DeviceType.Hardware, Handle,
                CreateFlags.HardwareVertexProcessing, presentParameters);

            DrawFactory.DrawLineValue = new Line(DrawFactory.Device);
            DrawFactory.DrawBoxLine = new Line(DrawFactory.Device);
            DrawFactory.DrawCircleLine = new Line(DrawFactory.Device);
            DrawFactory.DrawFilledBoxLine = new Line(DrawFactory.Device);
            DrawFactory.DrawTriLine = new Line(DrawFactory.Device);

            var fontDescription = new FontDescription()
            {
                FaceName = "Fixedsys Regular",
                CharacterSet = FontCharacterSet.Default,
                Height = 20,
                Weight = FontWeight.Bold,
                MipLevels = 0,
                OutputPrecision = FontPrecision.Default,
                PitchAndFamily = FontPitchAndFamily.Default,
                Quality = FontQuality.ClearType
            };

            DrawFactory.Font = new Font(DrawFactory.Device, fontDescription);
            DrawFactory.InitialiseCircleDrawing(DrawFactory.Device);

            StartRenderLoop();
        }

        public void OnPaint()
        {
            DrawFactory.Marg.Left = 0;
            DrawFactory.Marg.Top = 0;
            DrawFactory.Marg.Right = Width;
            DrawFactory.Marg.Bottom = Height;

            NativeImport.DwmExtendFrameIntoClientArea(Handle, ref DrawFactory.Marg);
        }
    }
}