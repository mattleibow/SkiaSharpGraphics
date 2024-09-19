using SkiaSharp;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SkiaSharpGraphics.Graphics
{
	public class Line : Shape
	{
		public static readonly BindableProperty X1Property = BindableProperty.Create(
			nameof(X1), typeof(double), typeof(Line), 0.0, propertyChanged: OnLineChanged);

		public static readonly BindableProperty Y1Property = BindableProperty.Create(
			nameof(Y1), typeof(double), typeof(Line), 0.0, propertyChanged: OnLineChanged);

		public static readonly BindableProperty X2Property = BindableProperty.Create(
			nameof(X2), typeof(double), typeof(Line), 0.0, propertyChanged: OnLineChanged);

		public static readonly BindableProperty Y2Property = BindableProperty.Create(
			nameof(Y2), typeof(double), typeof(Line), 0.0, propertyChanged: OnLineChanged);

		private SKPath path;

		public double X1
		{
			get { return (double)GetValue(X1Property); }
			set { SetValue(X1Property, value); }
		}

		public double Y1
		{
			get { return (double)GetValue(Y1Property); }
			set { SetValue(Y1Property, value); }
		}

		public double X2
		{
			get { return (double)GetValue(X2Property); }
			set { SetValue(X2Property, value); }
		}

		public double Y2
		{
			get { return (double)GetValue(Y2Property); }
			set { SetValue(Y2Property, value); }
		}

		public override SKPath GetPath()
		{
			if (path != null)
			{
				return path;
			}

			path = new SKPath();
			path.MoveTo((float)X1, (float)Y1);
			path.LineTo((float)X2, (float)Y2);

			return path;
		}

		private static void OnLineChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is Line line)
			{
				line.path?.Dispose();
				line.path = null;
			}

			OnGraphicsChanged(bindable, oldValue, newValue);
		}
	}
}
