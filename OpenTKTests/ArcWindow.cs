using System;
using System.Diagnostics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace OpenTKTests
{
	public class ArcWindow : GameWindow
	{
		private string _fps;
		private DateTimeOffset _lastCheck;
		private readonly Random _ran = new();
		
		public ArcWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings) { }

		protected override void OnRenderFrame(FrameEventArgs args)
		{
			base.OnRenderFrame(args);

			var fps = $"FPS: {1000 / this.RenderTime:F0}";
			_ = this.Title.Contains("FPS:") ? this.Title = this.Title.Replace(_fps, fps) : this.Title += fps;

			_fps = fps;
		}

		protected override void OnLoad()
		{
			//GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
			base.OnLoad();
			
		}

		protected override void OnUpdateFrame(FrameEventArgs args)
		{

			base.OnUpdateFrame(args);
		}
	}
}