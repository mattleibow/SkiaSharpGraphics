using System;
using SkiaSharp;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SkiaSharpGraphics.Graphics
{
	[ContentProperty(nameof(GradientStops))]
	public class GradientBrush : Brush
	{
		protected GradientBrush()
		{
		}

		protected GradientBrush(GradientStopCollection gradientStopCollection)
		{
			GradientStops = gradientStopCollection;
		}

		public GradientSpreadMethod SpreadMethod { get; set; } = GradientSpreadMethod.Pad;

		public BrushMappingMode MappingMode { get; set; } = BrushMappingMode.RelativeToBoundingBox;

		public GradientStopCollection GradientStops { get; set; } = new GradientStopCollection();

		public override SKPaint GetPaint(SKRect bounds)
		{
			var paint = base.GetPaint(bounds);

			paint.Color = SKColors.Black;
			paint.Shader = GetShader(bounds);

			return paint;
		}

		protected virtual SKShader GetShader(SKRect bounds)
		{
			return null;
		}

		protected SKShaderTileMode GetShaderTileMode()
		{
			var mode = SKShaderTileMode.Clamp;
			switch (SpreadMethod)
			{
				case GradientSpreadMethod.Pad:
					mode = SKShaderTileMode.Clamp;
					break;
				case GradientSpreadMethod.Reflect:
					mode = SKShaderTileMode.Mirror;
					break;
				case GradientSpreadMethod.Repeat:
					mode = SKShaderTileMode.Repeat;
					break;
			}

			return mode;
		}

		protected SKPoint GetRelative(SKPoint point, SKRect bounds)
		{
			if (MappingMode == BrushMappingMode.RelativeToBoundingBox)
			{
				point = new SKPoint(point.X * bounds.Width, point.Y * bounds.Height);
			}
			return point;
		}

		protected double GetRelative(double value, double size)
		{
			if (MappingMode == BrushMappingMode.RelativeToBoundingBox)
			{
				value = value * size;
			}
			return value;
		}
	}
}
