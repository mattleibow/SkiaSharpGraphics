using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharpDemo
{
	public class Rectangle : GraphicsElement
	{
		private SKPaint paint;

		public Rectangle()
		{
			paint = new SKPaint();
			paint.IsAntialias = true;
		}

		public override void OnPaint(SKPaintSurfaceEventArgs e)
		{
			var canvas = e.Surface.Canvas;

			paint.Style = SKPaintStyle.Fill;
			paint.Color = FillColor.ToSKColor();
			canvas.DrawRect(SKRect.Create(Left, Top, Width, Height), paint);

			paint.Style = SKPaintStyle.Stroke;
			paint.Color = StrokeColor.ToSKColor();
			paint.StrokeWidth = StrokeWidth;
			canvas.DrawRect(SKRect.Create(Left, Top, Width, Height), paint);

			base.OnPaint(e);
		}
	}
}
