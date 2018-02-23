using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharpDemo.Graphics
{
	public class Line : Shape
	{
		private SKPath path;

		public float X1 { get; set; } = 0.0f;

		public float Y1 { get; set; } = 0.0f;

		public float X2 { get; set; } = 0.0f;

		public float Y2 { get; set; } = 0.0f;

		public override SKPath GetPath()
		{
			if (path == null)
			{
				path = new SKPath();
				path.MoveTo(X1, Y1);
				path.LineTo(X2, Y2);
			}

			return path;
		}
	}
}
