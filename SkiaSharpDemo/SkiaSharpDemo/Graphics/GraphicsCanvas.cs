using System.Collections.Generic;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaSharpDemo.Graphics
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

			if (child is GraphicsElement element)
			{
				(child.Parent as GraphicsCanvas)?.children.Remove(element);
				children.Add(element);
			}
		}

		protected override void OnChildRemoved(Element child)
		{
			base.OnChildRemoved(child);

			if (child is GraphicsElement element)
			{
				children.Remove(element);
			}
		}

		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			base.OnPaintSurface(e);

			var canvas = e.Surface.Canvas;

			canvas.Clear(SKColors.Transparent);

			// apply scaling
			var scale = e.Info.Width / Width;
			canvas.Scale((float)scale);

			foreach (var child in children)
			{
				if (child.IsVisibile)
				{
					child.Paint(canvas);
				}
			}
		}
	}
}
