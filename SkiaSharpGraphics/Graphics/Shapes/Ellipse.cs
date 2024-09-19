using System.Runtime.CompilerServices;
using SkiaSharp;

namespace SkiaSharpGraphics.Graphics
{
	public class Ellipse : Shape
	{
		private SKPath path;

		public Ellipse()
		{
		}

		public override SKPath GetPath()
		{
			if (path != null)
			{
				return path;
			}

			path = new SKPath();
			var rect = SKRect.Create(0, 0, (float)Width, (float)Height);
			path.AddOval(rect);

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
	}
}
