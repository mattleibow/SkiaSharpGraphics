using System;
using SkiaSharp;
using Xamarin.Forms;

namespace SkiaSharpDemo.Graphics
{
	[TypeConverter(typeof(BrushConverter))]
	public class Brush
	{
		private SKPaint paint;

		protected Brush()
		{
		}

		//public Transform Transform { get; set; } = ?;

		//public Transform RelativeTransform { get; set; } = ?;

		//public double Opacity { get; set; } = ?;

		public virtual SKPaint GetPaint(SKRect bounds)
		{
			if (paint != null)
			{
				return paint;
			}

			paint = new SKPaint
			{
				IsAntialias = true,
				FilterQuality = SKFilterQuality.High,
				Color = SKColors.Transparent,
				Style = SKPaintStyle.Fill
			};

			return paint;
		}

		public static bool TryParse(string value, out Brush brush)
		{
			try
			{
				var colorConverter = new ColorTypeConverter();
				var color = (Color)colorConverter.ConvertFromInvariantString(value);
				brush = new SolidColorBrush(color);
				return true;
			}
			catch
			{
				brush = null;
				return false;
			}
		}
	}
}
