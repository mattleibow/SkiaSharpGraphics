//using SkiaSharp;
//using Microsoft.Maui.Graphics;
//using Microsoft.Maui.Controls.Compatibility;
//using Microsoft.Maui.Controls;
//using Microsoft.Maui;
//using SkiaSharp.Views.Maui.Controls;
//using SkiaSharp.Views.Maui;

//namespace SkiaSharpGraphics.Graphics
//{
//    public class SolidColorBrush : Fill
//    {
//        private Color color = Colors.Transparent;

//        public SolidColorBrush()
//        {
//        }

//        public SolidColorBrush(Color color)
//        {
//            Color = color;
//        }

//        public Color Color
//        {
//            get => color;
//            set
//            {
//                color = value;
//                Invalidate();
//            }
//        }

//        protected override void UpdatePaint(SKPaint paint, SKRect bounds)
//        {
//            base.UpdatePaint(paint, bounds);
            
//            paint.Color = Color.ToSKColor();
//        }
//    }
//}
