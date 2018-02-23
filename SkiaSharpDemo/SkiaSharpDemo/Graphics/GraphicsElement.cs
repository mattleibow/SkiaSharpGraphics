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

		//public float Opacity { get; set; } = 1.0f;

		public bool IsVisibile { get; set; } = true;

		//public Rect Clip { get; set; } = ?;

		public bool ClipToBounds { get; set; } = false;

		public float Left { get; set; } = 0;

		public float Top { get; set; } = 0;

		public float Width { get; set; } = 0;

		public float Height { get; set; } = 0;

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
				if (ClipToBounds)
				{
					canvas.ClipRect(SKRect.Create(Left, Top, Width, Height), SKClipOperation.Intersect, true);
				}

				canvas.Translate(Left, Top);

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
