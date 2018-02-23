using System;
using Xamarin.Forms;

namespace SkiaSharpDemo.Graphics
{
	public class BrushConverter : TypeConverter
	{
		public override object ConvertFromInvariantString(string value)
		{
			if (!string.IsNullOrWhiteSpace(value))
			{
				if (Brush.TryParse(value, out Brush brush))
				{
					return brush;
				}
			}

			throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Brush)}.");
		}
	}
}
