using System;
using Xamarin.Forms;
using SkiaSharp;

namespace SkiaSharpDemo.Graphics
{
	public class Path : Shape
	{
		public static readonly BindableProperty DataProperty = BindableProperty.Create(
			nameof(Data), typeof(string), typeof(Path), (string)null, propertyChanged: OnDataChanged);

		private SKPath path;

		public string Data
		{
			get { return (string)GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}

		public override SKPath GetPath()
		{
			if (path != null)
			{
				return path;
			}

			if (string.IsNullOrWhiteSpace(Data))
			{
				return null;
			}

			var fillRule = SKPathFillType.EvenOdd;

			var index = 0;

			// skip any leading space
			while ((index < Data.Length) && char.IsWhiteSpace(Data, index))
			{
				index++;
			}

			// is there anything to look at?
			if (index < Data.Length)
			{
				// if so, we only care if the first non-WhiteSpace char encountered is 'F'
				if (Data[index] == 'F')
				{
					index++;

					// since we found 'F' the next non-WhiteSpace char must be 0 or 1 - look for it.
					while ((index < Data.Length) && char.IsWhiteSpace(Data, index))
					{
						index++;
					}

					// if we ran out of text, this is an error, because 'F' cannot be specified without 0 or 1
					// also, if the next token isn't 0 or 1, this too is illegal
					if ((index == Data.Length) || ((Data[index] != '0') && (Data[index] != '1')))
					{
						throw new FormatException("An illegal character was encountered while parsing the path data.");
					}

					fillRule = Data[index] == '0' ? SKPathFillType.EvenOdd : SKPathFillType.Winding;

					// increment index to point to the next char
					index++;
				}
			}

			path = SKPath.ParseSvgPathData(Data.Substring(index));

			path.FillType = fillRule;

			return path;
		}

		private static void OnDataChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is Path pathShape)
			{
				pathShape.path?.Dispose();
				pathShape.path = null;
			}

			OnGraphicsChanged(bindable, oldValue, newValue);
		}
	}
}
