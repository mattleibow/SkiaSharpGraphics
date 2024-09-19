using System;
using System.ComponentModel;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using System.Globalization;

namespace SkiaSharpGraphics.Graphics
{
	public class PointCollectionConverter : TypeConverter
	{
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
			if (value is string str && !string.IsNullOrWhiteSpace(str))
			{
				if (PointCollection.TryParse(str, out PointCollection points))
				{
					return points;
				}
			}

			throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(PointCollection)}.");
		}
	}
}
