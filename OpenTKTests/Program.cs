using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace OpenTKTests
{
	public class Program
	{
		static void Main(string[] args)
		{
			using var win = new ArcWindow(new() { RenderFrequency = 0, UpdateFrequency = 30, IsMultiThreaded = true}, NativeWindowSettings.Default)
			{
				Title = "ArcEngine OpenTK Test | ",
				Size = new Vector2i(600)
			};
			
			win.Run();
		}
	}
}