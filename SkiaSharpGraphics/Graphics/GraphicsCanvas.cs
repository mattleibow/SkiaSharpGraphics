using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace SkiaSharpGraphics.Graphics
{
    [ContentProperty(nameof(Operations))]
    public class GraphicsCanvas : SKCanvasView, IGraphicsOperationContainer, IGraphicsCanvasRenderer
    {
        private readonly GraphicsCanvasRenderer renderer;

        public GraphicsCanvas()
        {
            IgnorePixelScaling = true;

            renderer = new GraphicsCanvasRenderer(this, InvalidateSurface);
        }

        public GraphicsOperationCollection Operations => renderer.Operations;

        void IGraphicsCanvasRenderer.Invalidate() => renderer.Invalidate();

        public void SuspendRender() => renderer.SuspendRender();

        public void ResumeRender(bool performRender = false) => renderer.ResumeRender(performRender);

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            var canvas = e.Surface.Canvas;

            canvas.Clear(SKColors.Transparent);

            foreach (var operation in Operations)
            {
                if (!operation.IsEnabled)
                    continue;

                operation.Execute(canvas);
            }
        }
    }
}
