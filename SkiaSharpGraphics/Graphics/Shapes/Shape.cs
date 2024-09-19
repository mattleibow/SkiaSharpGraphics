//using Microsoft.Maui.Graphics.Converters;
//using SkiaSharp;
//using SkiaSharp.Views.Maui;

//namespace SkiaSharpGraphics.Graphics;

//public class Paint
//{
//    private SKPaint? paint;
//    private SKRect lastBounds;

//    protected void Invalidate()
//    {
//        if (paint is not null)
//        {
//            OnUpdate(paint, lastBounds);
//        }
//    }

//    protected virtual void OnUpdate(SKPaint paint, SKRect bounds)
//    {
//        paint.IsAntialias = true;
//        paint.FilterQuality = SKFilterQuality.High;
//        paint.Color = SKColors.Transparent;
//    }

//    public virtual SKPaint GetPaint(SKRect bounds)
//    {
//        if (paint is not null && lastBounds == bounds)
//            return paint;

//        lastBounds = bounds;

//        paint ??= new SKPaint();

//        OnUpdate(paint, bounds);

//        return paint;
//    }
//}

//public class Stroke : Paint
//{
//    public double Thickness { get; set; }

//    protected override void OnUpdate(SKPaint paint, SKRect bounds)
//    {
//        base.OnUpdate(paint, bounds);

//        paint.Style = SKPaintStyle.Stroke;
//        paint.StrokeWidth = (float)Thickness;
//    }
//}

//public abstract class Fill : Paint
//{
//    protected override void OnUpdate(SKPaint paint, SKRect bounds)
//    {
//        base.OnUpdate(paint, bounds);
        
//        paint.Style = SKPaintStyle.Fill;
//    }
//}

//public abstract class Shape : GraphicsOperation
//{
//    public static readonly BindableProperty FillProperty = BindableProperty.Create(
//        nameof(Fill), typeof(Brush), typeof(Fill), null, propertyChanged: OnGraphicsChanged);

//    public static readonly BindableProperty StrokeProperty = BindableProperty.Create(
//        nameof(Stroke), typeof(Brush), typeof(Stroke), null, propertyChanged: OnGraphicsChanged);

//    protected Shape()
//    {
//    }

//    public Fill? Fill
//    {
//        get { return (Fill?)GetValue(FillProperty); }
//        set { SetValue(FillProperty, value); }
//    }

//    public Stroke? Stroke
//    {
//        get { return (Stroke?)GetValue(StrokeProperty); }
//        set { SetValue(StrokeProperty, value); }
//    }

//    public abstract SKPath GetPath();

//    protected override void OnExecute(SKCanvas canvas)
//    {
//        var path = GetPath();
//        if (path != null)
//        {
//            var bounds = path.Bounds;

//            var fill = Fill?.GetPaint(bounds);
//            if (fill is not null)
//            {
//                canvas.DrawPath(path, fill);
//            }

//            var stroke = Stroke?.GetPaint(bounds);
//            if (stroke is not null)
//            {
//                canvas.DrawPath(path, stroke);
//            }
//        }
//    }
//}
