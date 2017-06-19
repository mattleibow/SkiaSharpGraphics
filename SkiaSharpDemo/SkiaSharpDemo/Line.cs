using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharpDemo
{
	public class Line : GraphicsElement
	{
		private SKPaint paint;

		public Line()
		{
			paint = new SKPaint();
			paint.IsAntialias = true;
		}

		public override void OnPaint(SKPaintSurfaceEventArgs e)
		{
			var canvas = e.Surface.Canvas;

			paint.Style = SKPaintStyle.Stroke;
			paint.Color = StrokeColor.ToSKColor();
			paint.StrokeWidth = StrokeWidth;
			canvas.DrawLine(Left, Top, Left + Width, Top + Height, paint);

			base.OnPaint(e);
		}
	}
}
