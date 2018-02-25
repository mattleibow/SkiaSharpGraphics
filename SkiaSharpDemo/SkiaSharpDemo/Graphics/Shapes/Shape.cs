using Xamarin.Forms;
using SkiaSharp;

namespace SkiaSharpDemo.Graphics
{
	public class Shape : GraphicsElement
	{
		public static readonly BindableProperty FillProperty = BindableProperty.Create(
			nameof(Fill), typeof(Brush), typeof(Shape), null, propertyChanged: OnFillChanged);

		public static readonly BindableProperty StrokeProperty = BindableProperty.Create(
			nameof(Stroke), typeof(Brush), typeof(Shape), null, propertyChanged: OnStrokeChanged);

		public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create(
			nameof(StrokeThickness), typeof(double), typeof(Shape), 1.0, propertyChanged: OnStrokeChanged);

		private SKPaint fillPaint;
		private SKPaint strokePaint;

		protected Shape()
		{
		}

		//public DoubleCollection StrokeDashArray { get; set; } = ?;

		//public PenLineCap StrokeDashCap { get; set; } = ?;

		//public double StrokeDashOffset { get; set; } = ?;

		//public PenLineCap StrokeStartLineCap { get; set; } = ?;

		//public PenLineCap StrokeEndLineCap { get; set; } = ?;

		//public double StrokeMiterLimit { get; set; } = ?;

		//public PenLineJoin StrokeLineJoin { get; set; } = ?;

		//public Transform GeometryTransform { get; } = ?;

		public Brush Fill
		{
			get { return (Brush)GetValue(FillProperty); }
			set { SetValue(FillProperty, value); }
		}

		public Brush Stroke
		{
			get { return (Brush)GetValue(StrokeProperty); }
			set { SetValue(StrokeProperty, value); }
		}

		public double StrokeThickness
		{
			get { return (double)GetValue(StrokeThicknessProperty); }
			set { SetValue(StrokeThicknessProperty, value); }
		}

		public virtual SKPath GetPath()
		{
			return null;
		}

		public virtual SKPaint GetFillPaint(SKRect bounds)
		{
			if (fillPaint != null)
			{
				return fillPaint;
			}

			if (Fill == null)
			{
				return null;
			}

			fillPaint = Fill.GetPaint(bounds).Clone();
			fillPaint.Style = SKPaintStyle.Fill;

			return fillPaint;
		}

		public virtual SKPaint GetStrokePaint(SKRect bounds)
		{
			if (strokePaint != null)
			{
				return strokePaint;
			}

			if (Stroke == null)
			{
				return null;
			}

			strokePaint = Stroke.GetPaint(bounds).Clone();
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

		private static void OnFillChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is Shape shape)
			{
				shape.fillPaint?.Dispose();
				shape.fillPaint = null;
			}

			OnGraphicsChanged(bindable, oldValue, newValue);
		}

		private static void OnStrokeChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is Shape shape)
			{
				shape.strokePaint?.Dispose();
				shape.strokePaint = null;
			}

			OnGraphicsChanged(bindable, oldValue, newValue);
		}
	}
}
