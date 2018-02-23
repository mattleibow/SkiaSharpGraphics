using System.Collections.Generic;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpDemo.Graphics
{
	public class Shape : GraphicsElement
	{
		private SKPaint fillPaint;
		private SKPaint strokePaint;

		//public SingleCollection StrokeDashArray { get; set; } = ?;

		public Brush Stroke { get; set; } = null;

		//public PenLineCap StrokeDashCap { get; set; } = ?;

		//public float StrokeDashOffset { get; set; } = ?;

		public Brush Fill { get; set; } = null;

		public float StrokeThickness { get; set; } = 1.0f;

		//public PenLineCap StrokeStartLineCap { get; set; } = ?;

		//public PenLineCap StrokeEndLineCap { get; set; } = ?;

		//public float StrokeMiterLimit { get; set; } = ?;

		//public PenLineJoin StrokeLineJoin { get; set; } = ?;

		//public Transform GeometryTransform { get; } = ?;

		public virtual SKPath GetPath()
		{
			return null;
		}

		public virtual SKPaint GetFillPaint()
		{
			if (Fill == null)
			{
				return null;
			}

			if (fillPaint == null)
			{
				fillPaint = Fill.GetPaint().Clone();
			}

			fillPaint.Style = SKPaintStyle.Fill;
			return fillPaint;
		}

		public virtual SKPaint GetStrokePaint()
		{
			if (Stroke == null)
			{
				return null;
			}

			if (strokePaint == null)
			{
				strokePaint = Stroke.GetPaint().Clone();
			}

			strokePaint.Style = SKPaintStyle.Stroke;
			strokePaint.StrokeWidth = StrokeThickness;
			return strokePaint;
		}

		protected override void OnPaint(SKCanvas canvas)
		{
			base.OnPaint(canvas);

			var fill = GetFillPaint();
			var stroke = GetStrokePaint();
			if (fill != null || stroke != null)
			{
				var path = GetPath();
				if (path != null)
				{
					if (fill != null)
					{
						canvas.DrawPath(path, fill);
					}

					if (stroke != null)
					{
						canvas.DrawPath(path, stroke);
					}
				}
			}
		}
	}
}
