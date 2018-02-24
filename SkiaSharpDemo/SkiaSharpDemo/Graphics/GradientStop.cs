using SkiaSharp;
using Xamarin.Forms;

namespace SkiaSharpDemo.Graphics
{
	public class GradientStop
	{
		public GradientStop()
		{
		}

		public GradientStop(Color color, double offset)
		{
			Color = color;
			Offset = offset;
		}

		public Color Color { get; set; } = Color.Transparent;

		public double Offset { get; set; } = 0.0f;
	}
}
