using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace SkiaSharpGraphics.Graphics;

public class Paint
{
    public virtual void Apply(SKPaint paint)
    {
    }
}

public class SolidColor : Paint
{
    public Color? Color { get; set; }

    public override void Apply(SKPaint paint)
    {
        base.Apply(paint);
        paint.ColorF = Color?.ToSKColorF() ?? SKColors.Transparent;
    }
}

public class Fill : Paintbrush
{
    public override SKPaint GetPaint()
    {
        var paint = base.GetPaint();
        paint.Style = SKPaintStyle.Fill;
        return paint;
    }

}

public class Stroke : Paintbrush
{
    public double Thickness { get; set; }

    public override SKPaint GetPaint()
    {
        var paint = base.GetPaint();
        paint.Style = SKPaintStyle.Stroke;
        paint.StrokeWidth = (float)Thickness;
        return paint;
    }
}

public abstract class Paintbrush
{
    private SKPaint? paint;

    public Paint? Paint { get; set; }

    public virtual SKPaint GetPaint()
    {
        paint ??= new SKPaint();
        Paint?.Apply(paint);
        return paint;
    }
}

public abstract class Shape : GraphicsOperation
{
    public Fill? Fill { get; set; }

    public Stroke? Stroke { get; set; }

}

public abstract class Transform : GraphicsOperation
{
}

public class Translate : Transform
{
    public double X { get; set; }

    public double Y { get; set; }

    protected override void OnExecute(SKCanvas canvas)
    {
        canvas.Translate((float)X, (float)Y);
    }
}


public class Rectangle : Shape
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    protected override void OnExecute(SKCanvas canvas)
    {
        var rect = new Rect(X, Y, Width, Height).ToSKRect();

        if (Fill is not null)
            canvas.DrawRect(rect, Fill.GetPaint());

        if (Stroke is not null)
            canvas.DrawRect(rect, Stroke.GetPaint());
    }
}

[ContentProperty(nameof(Operations))]
public abstract class GraphicsOperation : Element, IGraphicsOperationContainer
{
    public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(
        nameof(IsEnabled), typeof(bool), typeof(GraphicsOperation), true, propertyChanged: OnGraphicsChanged);

    private readonly GraphicsOperationCollection operations;

    public GraphicsOperation()
    {
        operations = new GraphicsOperationCollection(this);
    }

    public GraphicsOperationCollection Operations => operations;

    public bool IsEnabled
    {
        get => (bool)GetValue(IsEnabledProperty);
        set => SetValue(IsEnabledProperty, value);
    }

    public void Execute(SKCanvas canvas)
    {
        using var auto = new SKAutoCanvasRestore(canvas, true);

        OnExecute(canvas);

        foreach (var child in operations)
        {
            if (!child.IsEnabled)
                continue;

            child.Execute(canvas);
        }
    }

    protected abstract void OnExecute(SKCanvas canvas);

    protected IGraphicsCanvasRenderer? GetGraphicsCanvasRenderer()
    {
        var parent = Parent;
        while (parent is not null)
        {
            if (parent is IGraphicsCanvasRenderer renderer)
                return renderer;

            parent = parent.Parent;
        }

        return null;
    }

    protected static void OnGraphicsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not GraphicsOperation operation)
            return;

        operation.GetGraphicsCanvasRenderer()?.Invalidate();
    }
}
