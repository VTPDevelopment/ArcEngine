using System;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace OpenTKTests.Shaders
{
	public class Shader : IDisposable
	{
		private readonly int _handle;
		
		public Shader(string vertexShaderPath, string fragShaderPath)
		{
			int vert,
				frag;

			string vertSource, fragSource;
			
			using var vreader = new StreamReader(vertexShaderPath, Encoding.UTF8);
			using var freader = new StreamReader(fragShaderPath, Encoding.UTF8);

			vertSource = vreader.ReadToEnd();
			fragSource = freader.ReadToEnd();


			vert = GL.CreateShader(ShaderType.VertexShader);
			GL.ShaderSource(vert, vertSource);

			frag = GL.CreateShader(ShaderType.FragmentShader);
			GL.ShaderSource(frag, fragSource);
			
			GL.CompileShader(vert);

			string infoLogVert = GL.GetShaderInfoLog(vert);
			
			if (!string.IsNullOrEmpty(infoLogVert))
				Console.WriteLine(infoLogVert);

			GL.CompileShader(frag);

			string infoLogFrag = GL.GetShaderInfoLog(frag);

			if (!string.IsNullOrEmpty(infoLogFrag))
				Console.WriteLine(infoLogFrag);


			_handle = GL.CreateProgram();
			
			GL.AttachShader(_handle, vert);
			GL.AttachShader(_handle, frag);
			
			GL.LinkProgram(_handle);
			
			GL.DetachShader(_handle, vert);
			GL.DetachShader(_handle, frag);
			GL.DeleteShader(vert);
			GL.DeleteShader(frag);
		}

		public void Use() => GL.UseProgram(_handle);
		
		
		public void Dispose()
		{
			ReleaseUnmanagedResources();
			GC.SuppressFinalize(this);
		}
		
		~Shader() => ReleaseUnmanagedResources();
		
		private void ReleaseUnmanagedResources() => GL.DeleteProgram(_handle);
	}
}