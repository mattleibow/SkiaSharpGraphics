namespace SkiaSharpDemo.Graphics
{
	public interface IGraphicsCanvasRenderer
	{
		GraphicsElementCollection Children { get; }

		void Invalidate();

		void SuspendRender();
		void ResumeRender(bool performRender = false);
	}
}
