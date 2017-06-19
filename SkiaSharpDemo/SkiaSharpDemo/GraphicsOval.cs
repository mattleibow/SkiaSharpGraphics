using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharpDemo
{
	public class GraphicsOval : GraphicsElement
	{
		private SKPaint paint;

		public GraphicsOval()
		{
			paint = new SKPaint();
		}

		public float Left { get; set; }

		public float Top { get; set; }

		public float Width { get; set; }

		public float Height { get; set; }

		public Color FillColor { get; set; }

		public Color StrokeColor { get; set; }

		public float StrokeWidth { get; set; }

		public override void OnPaint(SKPaintSurfaceEventArgs e)
		{
			var canvas = e.Surface.Canvas;

			paint.Style = SKPaintStyle.Fill;
			paint.Color = FillColor.ToSKColor();
			canvas.DrawOval(SKRect.Create(Left, Top, Width, Height), paint);

			paint.Style = SKPaintStyle.Stroke;
			paint.Color = StrokeColor.ToSKColor();
			paint.StrokeWidth = StrokeWidth;
			canvas.DrawOval(SKRect.Create(Left, Top, Width, Height), paint);

			base.OnPaint(e);
		}
	}
}
