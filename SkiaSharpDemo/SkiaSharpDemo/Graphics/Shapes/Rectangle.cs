using System.Runtime.CompilerServices;
using Xamarin.Forms;
using SkiaSharp;

namespace SkiaSharpDemo.Graphics
{
	public class Rectangle : Shape
	{
		public static readonly BindableProperty RadiusXProperty = BindableProperty.Create(
			nameof(RadiusX), typeof(double), typeof(Rectangle), 0.0, propertyChanged: OnRadiusChanged);

		public static readonly BindableProperty RadiusYProperty = BindableProperty.Create(
			nameof(RadiusY), typeof(double), typeof(Rectangle), 0.0, propertyChanged: OnRadiusChanged);

		private SKPath path;

		public double RadiusX
		{
			get { return (double)GetValue(RadiusXProperty); }
			set { SetValue(RadiusXProperty, value); }
		}

		public double RadiusY
		{
			get { return (double)GetValue(RadiusYProperty); }
			set { SetValue(RadiusYProperty, value); }
		}

		public override SKPath GetPath()
		{
			if (path != null)
			{
				return path;
			}

			path = new SKPath();
			var rect = SKRect.Create(0, 0, (float)Width, (float)Height);
			if (RadiusX > 0 || RadiusY > 0)
			{
				path.AddRoundedRect(rect, (float)RadiusX, (float)RadiusY);
			}
			else
			{
				path.AddRect(rect);
			}

			return path;
		}

		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			if (propertyName == WidthProperty.PropertyName || propertyName == HeightProperty.PropertyName)
			{
				path?.Dispose();
				path = null;
			}

			base.OnPropertyChanged(propertyName);
		}

		private static void OnRadiusChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is Rectangle rect)
			{
				rect.path?.Dispose();
				rect.path = null;
			}

			OnGraphicsChanged(bindable, oldValue, newValue);
		}
	}
}
