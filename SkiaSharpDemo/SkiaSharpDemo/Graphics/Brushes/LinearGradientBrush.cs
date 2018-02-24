using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Linq;
using Xamarin.Forms;

namespace SkiaSharpDemo.Graphics
{
	public class LinearGradientBrush : GradientBrush
	{
		private SKShader shader;

		public LinearGradientBrush()
		{
		}

		public LinearGradientBrush(Color startColor, Color endColor, double angle)
		{
			EndPoint = EndPointFromAngle(angle);

			GradientStops.Add(new GradientStop(startColor, 0.0f));
			GradientStops.Add(new GradientStop(endColor, 1.0f));
		}

		public LinearGradientBrush(Color startColor, Color endColor, Point startPoint, Point endPoint)
		{
			StartPoint = startPoint;
			EndPoint = endPoint;

			GradientStops.Add(new GradientStop(startColor, 0.0f));
			GradientStops.Add(new GradientStop(endColor, 1.0f));
		}

		public LinearGradientBrush(GradientStopCollection gradientStopCollection)
			: base(gradientStopCollection)
		{
		}

		public LinearGradientBrush(GradientStopCollection gradientStopCollection, double angle)
			: base(gradientStopCollection)
		{
			EndPoint = EndPointFromAngle(angle);
		}

		public LinearGradientBrush(GradientStopCollection gradientStopCollection, Point startPoint, Point endPoint)
			: base(gradientStopCollection)
		{
			StartPoint = startPoint;
			EndPoint = endPoint;
		}

		public Point StartPoint { get; set; }

		public Point EndPoint { get; set; }

		protected override SKShader GetShader(SKRect bounds)
		{
			if (shader == null)
			{
				var mode = GetShaderTileMode();
				var start = GetRelative(StartPoint.ToSKPoint(), bounds);
				var end = GetRelative(EndPoint.ToSKPoint(), bounds);
				var colors = GradientStops.Select(s => s.Color.ToSKColor()).ToArray();
				var positions = GradientStops.Select(s => (float)s.Offset).ToArray();

				shader = SKShader.CreateLinearGradient(start, end, colors, positions, mode);
			}

			return shader;
		}

		private Point EndPointFromAngle(double angle)
		{
			// Convert the angle from degrees to radians
			angle = angle * (1.0 / 180.0) * System.Math.PI;

			return new Point(System.Math.Cos(angle), System.Math.Sin(angle));
		}
	}
}
