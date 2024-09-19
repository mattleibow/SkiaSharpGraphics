//using System;
//using SkiaSharp;
//using Microsoft.Maui.Controls.Compatibility;
//using Microsoft.Maui.Controls;
//using Microsoft.Maui;

//namespace SkiaSharpGraphics.Graphics
//{
//	public class RadialGradientBrush : GradientBrush
//	{
//		private SKShader shader;

//		public RadialGradientBrush()
//		{
//		}

//		public RadialGradientBrush(Color startColor, Color endColor)
//		{
//			GradientStops.Add(new GradientStop(startColor, 0.0f));
//			GradientStops.Add(new GradientStop(endColor, 1.0f));
//		}

//		public RadialGradientBrush(GradientStopCollection gradientStopCollection)
//			: base(gradientStopCollection)
//		{
//		}

//		public Point Center { get; set; } = new Point(0.5, 0.5);

//		public Point GradientOrigin { get; set; } = new Point(0.5, 0.5);

//		public double RadiusX { get; set; } = 0.5f;

//		public double RadiusY { get; set; } = 0.5f;

//		protected override SKShader GetShader(SKRect bounds)
//		{
//			throw new NotImplementedException();
//		}
//	}
//}
