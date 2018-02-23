using SkiaSharp;

namespace SkiaSharpDemo.Graphics
{
	public class Ellipse : Shape
	{
		private SKPath path;

		public override SKPath GetPath()
		{
			if (path == null)
			{
				path = new SKPath();
				var rect = SKRect.Create(0, 0, Width, Height);
				path.AddOval(rect);
			}

			return path;
		}
	}
}
