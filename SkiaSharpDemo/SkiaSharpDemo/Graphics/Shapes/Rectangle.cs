using SkiaSharp;

namespace SkiaSharpDemo.Graphics
{
	public class Rectangle : Shape
	{
		private SKPath path;

		public double RadiusY { get; set; } = 0.0f;

		public double RadiusX { get; set; } = 0.0f;

		public override SKPath GetPath()
		{
			if (path == null)
			{
				path = new SKPath();
				var rect = SKRect.Create(0, 0, (float)Width, (float)Height);

				if (RadiusX > 0 || RadiusY > 0)
				{
					path.AddRoundedRect(rect, (float)RadiusX, (float)RadiusY);
				}
				else
				{
					path.AddRect(rect);
				}
			}

			return path;
		}
	}
}
