namespace SkiaSharpGraphics.Graphics;

public interface IGraphicsCanvasRenderer
{
    GraphicsOperationCollection Operations { get; }

    void Invalidate();

    void SuspendRender();

    void ResumeRender(bool performRender = false);
}
