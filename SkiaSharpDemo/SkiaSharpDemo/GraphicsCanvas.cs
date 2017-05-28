using System.Collections.Generic;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharpDemo
{
	[ContentProperty("Children")]
	public class GraphicsCanvas : SKCanvasView
	{
		private readonly List<GraphicsElement> children;

		public GraphicsCanvas()
		{
			children = new List<GraphicsElement>();
		}

		public IList<GraphicsElement> Children => children;

		protected override void OnChildAdded(Element child)
		{
			base.OnChildAdded(child);

			var element = child as GraphicsElement;
			if (element != null)
			{
				(child.Parent as GraphicsCanvas)?.children.Remove(element);
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

		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			base.OnPaintSurface(e);

			e.Surface.Canvas.Clear(SKColors.AliceBlue);

			foreach (var child in children)
			{
				child.OnPaint(e);
			}
		}
	}
}
