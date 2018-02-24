using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharpDemo.Graphics
{
	public class Line : Shape
	{
		private SKPath path;

		public double X1 { get; set; } = 0.0f;

		public double Y1 { get; set; } = 0.0f;

		public double X2 { get; set; } = 0.0f;

		public double Y2 { get; set; } = 0.0f;

		public override SKPath GetPath()
		{
			if (path == null)
			{
				path = new SKPath();
				path.MoveTo((float)X1, (float)Y1);
				path.LineTo((float)X2, (float)Y2);
			}

			return path;
		}
	}
}
