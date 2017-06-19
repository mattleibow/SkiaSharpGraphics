using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharpDemo
{
	public class Oval : GraphicsElement
	{
		private SKPaint paint;

		public Oval()
		{
			paint = new SKPaint();
			paint.IsAntialias = true;
		}

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
