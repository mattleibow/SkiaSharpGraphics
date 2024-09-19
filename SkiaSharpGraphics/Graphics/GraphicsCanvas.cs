using SkiaSharp;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using SkiaSharp.Views.Maui.Controls;
using SkiaSharp.Views.Maui;

namespace SkiaSharpGraphics.Graphics
{
	[ContentProperty("Children")]
	public class GraphicsCanvas : SKCanvasView, IGraphicsElementContainer, IGraphicsCanvasRenderer
	{
		private readonly GraphicsCanvasRenderer renderer;

		public GraphicsCanvas()
		{
			renderer = new GraphicsCanvasRenderer(this, InvalidateSurface);
		}

		public GraphicsElementCollection Children => renderer.Children;

		void IGraphicsCanvasRenderer.Invalidate() => renderer.Invalidate();

		public void SuspendRender() => renderer.SuspendRender();

		public void ResumeRender(bool performRender = false) => renderer.ResumeRender(performRender);

		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			base.OnPaintSurface(e);

			var canvas = e.Surface.Canvas;

			canvas.Clear(SKColors.Transparent);

			// apply scaling
			var scale = e.Info.Width / Width;
			canvas.Scale((float)scale);

			foreach (var child in Children)
			{
				if (child.IsVisibile)
				{
					child.Paint(canvas);
				}
			}
		}
	}
}
