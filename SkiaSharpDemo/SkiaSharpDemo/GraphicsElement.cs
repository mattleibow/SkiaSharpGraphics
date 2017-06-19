using System.Collections.Generic;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpDemo
{
	[ContentProperty("Children")]
	public class GraphicsElement : Element
	{
		private readonly List<GraphicsElement> children;

		public GraphicsElement()
		{
			children = new List<GraphicsElement>();
		}

		public IList<GraphicsElement> Children => children;

		public float Left { get; set; }

		public float Top { get; set; }

		public float Width { get; set; }

		public float Height { get; set; }

		public Color FillColor { get; set; }

		public Color StrokeColor { get; set; }

		public float StrokeWidth { get; set; }

		public bool ClipChildren { get; set; }

		protected override void OnChildAdded(Element child)
		{
			base.OnChildAdded(child);

			var element = child as GraphicsElement;
			if (element != null)
			{
				(child.Parent as GraphicsElement)?.children.Remove(element);
				children.Add(element);
			}
		}

		protected override void OnChildRemoved(Element child)
		{
			base.OnChildRemoved(child);

			var element = child as GraphicsElement;
			if (element != null)
			{
				children.Remove(element);
			}
		}

		public virtual void OnPaint(SKPaintSurfaceEventArgs e)
		{
			var canvas = e.Surface.Canvas;
			using (new SKAutoCanvasRestore(canvas, true))
			{
				if (ClipChildren)
				{
					canvas.ClipRect(SKRect.Create(Left, Top, Width, Height), SKClipOperation.Intersect, true);
				}

				canvas.Translate(Left, Top);

				foreach (var child in children)
				{
					child.OnPaint(e);
				}
			}
		}
	}
}
