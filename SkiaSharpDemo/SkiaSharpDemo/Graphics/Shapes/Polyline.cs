using SkiaSharp;
using System.Linq;

namespace SkiaSharpDemo.Graphics
{
	public class Polyline : Shape
	{
		public PointCollection Points { get; set; } = new PointCollection();

		public FillRule FillRule { get; set; } = FillRule.EvenOdd;

		public override SKPath GetPath()
		{
			if (Points == null || Points.Count == 0)
			{
				return null;
			}

			var points = Points.AsSKPointCollection();

			var path = new SKPath();
			path.MoveTo(points.First());
			foreach (var point in points.Skip(1))
			{
				path.LineTo(point);
			}
			return path;
		}
	}
}
