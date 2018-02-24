using System.Collections.Generic;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpDemo.Graphics
{
	public class Shape : GraphicsElement
	{
		private SKPaint fillPaint;
		private SKPaint strokePaint;

		protected Shape()
		{
		}

		//public DoubleCollection StrokeDashArray { get; set; } = ?;

		public Brush Stroke { get; set; } = null;

		//public PenLineCap StrokeDashCap { get; set; } = ?;

		//public double StrokeDashOffset { get; set; } = ?;

		public Brush Fill { get; set; } = null;

		public double StrokeThickness { get; set; } = 1.0f;

		//public PenLineCap StrokeStartLineCap { get; set; } = ?;

		//public PenLineCap StrokeEndLineCap { get; set; } = ?;

		//public double StrokeMiterLimit { get; set; } = ?;

		//public PenLineJoin StrokeLineJoin { get; set; } = ?;

		//public Transform GeometryTransform { get; } = ?;

		public virtual SKPath GetPath()
		{
			return null;
		}

		public virtual SKPaint GetFillPaint(SKRect bounds)
		{
			if (Fill == null)
			{
				return null;
			}

			if (fillPaint == null)
			{
				fillPaint = Fill.GetPaint(bounds).Clone();
			}

			fillPaint.Style = SKPaintStyle.Fill;
			return fillPaint;
		}

		public virtual SKPaint GetStrokePaint(SKRect bounds)
		{
			if (Stroke == null)
			{
				return null;
			}

			if (strokePaint == null)
			{
				strokePaint = Stroke.GetPaint(bounds).Clone();
			}

			strokePaint.Style = SKPaintStyle.Stroke;
			strokePaint.StrokeWidth = (float)StrokeThickness;
			return strokePaint;
		}

		protected override void OnPaint(SKCanvas canvas)
		{
			base.OnPaint(canvas);

			var path = GetPath();
			if (path != null)
			{
				var bounds = path.Bounds;

				var fill = GetFillPaint(bounds);
				if (fill != null)
				{
					canvas.DrawPath(path, fill);
				}

				var stroke = GetStrokePaint(bounds);
				if (stroke != null)
				{
					canvas.DrawPath(path, stroke);
				}
			}
		}
	}
}
