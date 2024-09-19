using System;
using System.ComponentModel;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using System.Globalization;

namespace SkiaSharpGraphics.Graphics
{
	public class BrushConverter : TypeConverter
	{
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
			if (value is string str && !string.IsNullOrWhiteSpace(str))
			{
				if (Brush.TryParse(str, out Brush brush))
				{
					return brush;
				}
			}

			throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Brush)}.");
		}
	}
}
