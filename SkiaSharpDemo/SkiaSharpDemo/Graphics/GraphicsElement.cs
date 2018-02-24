using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpDemo.Graphics
{
	[ContentProperty("Children")]
	public class GraphicsElement : Element
	{
		private readonly List<GraphicsElement> children = new List<GraphicsElement>();

		public IList<GraphicsElement> Children => children;

		//public double Opacity { get; set; } = 1.0f;

		public bool IsVisibile { get; set; } = true;

		//public Rect Clip { get; set; } = ?;

		public bool ClipToBounds { get; set; } = false;

		public double Left { get; set; } = 0;

		public double Top { get; set; } = 0;

		public double Width { get; set; } = 0;

		public double Height { get; set; } = 0;

		protected override void OnChildAdded(Element child)
		{
			base.OnChildAdded(child);

			if (child is GraphicsElement element)
			{
				(child.Parent as GraphicsElement)?.children.Remove(element);
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
	}
}
