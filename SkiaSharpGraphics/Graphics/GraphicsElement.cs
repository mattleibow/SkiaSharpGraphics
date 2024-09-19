using SkiaSharp;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SkiaSharpGraphics.Graphics
{
	[ContentProperty("Children")]
	public class GraphicsElement : Element, IGraphicsElementContainer
	{
		public static readonly BindableProperty IsVisibileProperty = BindableProperty.Create(
			nameof(IsVisibile), typeof(bool), typeof(GraphicsElement), true, propertyChanged: OnGraphicsChanged);

		public static readonly BindableProperty LeftProperty = BindableProperty.Create(
			nameof(Left), typeof(double), typeof(GraphicsElement), 0.0, propertyChanged: OnGraphicsChanged);

		public static readonly BindableProperty TopProperty = BindableProperty.Create(
			nameof(Top), typeof(double), typeof(GraphicsElement), 0.0, propertyChanged: OnGraphicsChanged);

		public static readonly BindableProperty WidthProperty = BindableProperty.Create(
			nameof(Width), typeof(double), typeof(GraphicsElement), 0.0, propertyChanged: OnGraphicsChanged);

		public static readonly BindableProperty HeightProperty = BindableProperty.Create(
			nameof(Height), typeof(double), typeof(GraphicsElement), 0.0, propertyChanged: OnGraphicsChanged);

		public static readonly BindableProperty ClipToBoundsProperty = BindableProperty.Create(
			nameof(ClipToBounds), typeof(bool), typeof(GraphicsElement), false, propertyChanged: OnGraphicsChanged);

		private readonly GraphicsElementCollection children;

		public GraphicsElement()
		{
			children = new GraphicsElementCollection(this);
		}

		public GraphicsElementCollection Children => children;

		//public double Opacity { get; set; } = 1.0f;

		//public Rect Clip { get; set; } = ?;

		public bool IsVisibile
		{
			get { return (bool)GetValue(IsVisibileProperty); }
			set { SetValue(IsVisibileProperty, value); }
		}

		public double Left
		{
			get { return (double)GetValue(LeftProperty); }
			set { SetValue(LeftProperty, value); }
		}

		public double Top
		{
			get { return (double)GetValue(TopProperty); }
			set { SetValue(TopProperty, value); }
		}

		public double Width
		{
			get { return (double)GetValue(WidthProperty); }
			set { SetValue(WidthProperty, value); }
		}

		public double Height
		{
			get { return (double)GetValue(HeightProperty); }
			set { SetValue(HeightProperty, value); }
		}

		public bool ClipToBounds
		{
			get { return (bool)GetValue(ClipToBoundsProperty); }
			set { SetValue(ClipToBoundsProperty, value); }
		}

		public void Paint(SKCanvas canvas)
		{
			using (new SKAutoCanvasRestore(canvas, true))
			{
				var bounds = SKRect.Create((float)Left, (float)Top, (float)Width, (float)Height);

				if (ClipToBounds)
				{
					canvas.ClipRect(bounds, SKClipOperation.Intersect, true);
				}

				canvas.Translate((float)Left, (float)Top);

				OnPaint(canvas);

				foreach (var child in children)
				{
					child.Paint(canvas);
				}
			}
		}

		protected virtual void OnPaint(SKCanvas canvas)
		{
		}

		protected IGraphicsCanvasRenderer GetGraphicsCanvasRenderer()
		{
			var parent = Parent;
			while (parent != null)
			{
				if (parent is IGraphicsCanvasRenderer renderer)
					return renderer;
				parent = parent.Parent;
			}
			return null;
		}

		protected static void InvalidateGraphicsCanvas(GraphicsElement element)
		{
			element.GetGraphicsCanvasRenderer()?.Invalidate();
		}

		protected static void OnGraphicsChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is GraphicsElement element)
			{
				InvalidateGraphicsCanvas(element);
			}
		}
	}
}
