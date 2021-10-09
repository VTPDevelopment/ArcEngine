using System;
using System.Diagnostics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTKTests.Shaders;

namespace OpenTKTests
{
	public class ArcWindow : GameWindow
	{
		private string _fps;
		private DateTimeOffset _lastCheck;

		private Shader _shader;

		private float[] _vertices = {
			-0.5f, -0.5f, 0.0f, //Bottom-left vertex
			0.5f, -0.5f, 0.0f, //Bottom-right vertex
			0.0f,  0.5f, 0.0f  //Top vertex
		};

		private int _vboHandle;
		

		public ArcWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings) { }

		protected override void OnRenderFrame(FrameEventArgs args)
		{
			base.OnRenderFrame(args);

			GL.Clear(ClearBufferMask.ColorBufferBit);

			SwapBuffers();

			var fps = $"FPS: {1000 / this.RenderTime:F0}";
			_ = this.Title.Contains("FPS:") ? this.Title = this.Title.Replace(_fps, fps) : this.Title += fps;

			_fps = fps;
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			GL.ClearColor(0.6f, 0.65f, 0.9f, 1.0f);

			_vboHandle = GL.GenBuffer();

			_shader = new("./Shaders/shader.vert", "./Shaders/shader.frag");
		}

		protected override void OnUpdateFrame(FrameEventArgs args)
		{
			base.OnUpdateFrame(args);
		}

		protected override void OnResize(ResizeEventArgs e)
		{
			base.OnResize(e);
			GL.Viewport(0, 0, Size.X, Size.Y);
		}

		protected override void OnUnload()
		{
			base.OnUnload();
			_shader.Dispose();
		}
	}
}