using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharpDemo.Graphics
{
	public class SolidColorBrush : Brush
	{
		public SolidColorBrush()
		{
		}

		public SolidColorBrush(Color color)
		{
			Color = color;
		}

		public Color Color { get; set; } = Color.Transparent;

		public override SKPaint GetPaint()
		{
			var paint = base.GetPaint();
			paint.Color = Color.ToSKColor();
			return paint;
		}
	}
}
