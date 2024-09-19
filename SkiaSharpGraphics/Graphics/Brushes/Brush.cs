using System;
using System.ComponentModel;
using SkiaSharp;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Graphics.Converters;

namespace SkiaSharpGraphics.Graphics
{
    [TypeConverter(typeof(BrushConverter))]
    public class Brush
    {
        private SKPaint paint;
        private SKRect lastBounds;

        protected Brush()
        {
        }

        //public Transform Transform { get; set; } = ?;

        //public Transform RelativeTransform { get; set; } = ?;

        //public double Opacity { get; set; } = ?;

        protected void Invalidate()
        {
            if (paint is not null)
            {
                UpdatePaint(paint, lastBounds);
            }
        }

        protected virtual void UpdatePaint(SKPaint paint, SKRect bounds)
        {
            paint.IsAntialias = true;
            paint.FilterQuality = SKFilterQuality.High;
            paint.Color = SKColors.Transparent;
            paint.Style = SKPaintStyle.Fill;
        }

        public virtual SKPaint GetPaint(SKRect bounds)
        {
            if (paint is not null && lastBounds == bounds)
                return paint;

            lastBounds = bounds;

            paint ??= new SKPaint();

            UpdatePaint(paint, bounds);

            return paint;
        }

        public static bool TryParse(string value, out Brush brush)
        {
            try
            {
                var colorConverter = new ColorTypeConverter();
                var color = (Color)colorConverter.ConvertFromInvariantString(value);
                brush = new SolidColorBrush(color);
                return true;
            }
            catch
            {
                brush = null;
                return false;
            }
        }
    }
}
