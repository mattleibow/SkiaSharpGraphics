using System;
using Xamarin.Forms;

namespace SkiaSharpDemo.Graphics
{
	public class PointCollectionConverter : TypeConverter
	{
		public override object ConvertFromInvariantString(string value)
		{
			if (!string.IsNullOrWhiteSpace(value))
			{
				if (PointCollection.TryParse(value, out PointCollection points))
				{
					return points;
				}
			}

			throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(PointCollection)}.");
		}
	}
}
