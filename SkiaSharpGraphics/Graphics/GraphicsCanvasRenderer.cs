using System;

namespace SkiaSharpGraphics.Graphics
{
	public class GraphicsCanvasRenderer : IGraphicsCanvasRenderer
	{
		private readonly GraphicsOperationCollection children;
		private readonly Action onInvalidateSurface;

		private int renderSuspendCount;
		private bool renderPending;

		public GraphicsCanvasRenderer(IGraphicsOperationContainer container, Action onInvalidate)
		{
			children = new GraphicsOperationCollection(container);
			onInvalidateSurface = onInvalidate;

			renderSuspendCount = 0;
			renderPending = false;
		}

		public GraphicsOperationCollection Operations => children;

		public void SuspendRender()
		{
			renderSuspendCount++;
		}

		public void ResumeRender(bool performRender = false)
		{
			if (renderSuspendCount > 0)
			{
				renderSuspendCount--;
			}

			if (renderSuspendCount == 0 && renderPending && performRender)
			{
				Invalidate();
			}
		}

		public void Invalidate()
		{
			if (renderSuspendCount == 0)
			{
				onInvalidateSurface();
				renderPending = false;
			}
			else
			{
				renderPending = true;
			}
		}
	}
}
