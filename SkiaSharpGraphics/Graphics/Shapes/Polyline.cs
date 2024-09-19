//using System.Linq;
//using SkiaSharp;
//using Microsoft.Maui.Controls.Compatibility;
//using Microsoft.Maui.Controls;
//using Microsoft.Maui;

//namespace SkiaSharpGraphics.Graphics
//{
//	public class Polyline : Shape
//	{
//		public static readonly BindableProperty PointsProperty = BindableProperty.Create(
//			nameof(Points), typeof(PointCollection), typeof(Polyline), new PointCollection(), propertyChanged: OnPathChanged);

//		public static readonly BindableProperty FillRuleProperty = BindableProperty.Create(
//			nameof(FillRule), typeof(FillRule), typeof(Polyline), FillRule.EvenOdd, propertyChanged: OnPathChanged);

//		private SKPath path;

//		public PointCollection Points
//		{
//			get { return (PointCollection)GetValue(PointsProperty); }
//			set { SetValue(PointsProperty, value); }
//		}

//		public FillRule FillRule
//		{
//			get { return (FillRule)GetValue(FillRuleProperty); }
//			set { SetValue(FillRuleProperty, value); }
//		}

//		public override SKPath GetPath()
//		{
//			if (path != null)
//			{
//				return path;
//			}

//			if (Points == null || Points.Count == 0)
//			{
//				return null;
//			}

//			var points = Points.AsSKPointCollection();

//			path = new SKPath();
//			path.MoveTo(points.First());
//			foreach (var point in points.Skip(1))
//			{
//				path.LineTo(point);
//			}

//			return path;
//		}

//		private static void OnPathChanged(BindableObject bindable, object oldValue, object newValue)
//		{
//			if (bindable is Polyline polyline)
//			{
//				polyline.path?.Dispose();
//				polyline.path = null;
//			}

//			OnGraphicsChanged(bindable, oldValue, newValue);
//		}
//	}
//}
