//using System.Linq;
//using SkiaSharp;
//using Microsoft.Maui.Controls.Compatibility;
//using Microsoft.Maui.Controls;
//using Microsoft.Maui;

//namespace SkiaSharpGraphics.Graphics
//{
//	public class Polygon : Shape
//	{
//		public static readonly BindableProperty PointsProperty = BindableProperty.Create(
//			nameof(Points), typeof(PointCollection), typeof(Polygon), new PointCollection(), propertyChanged: OnPathChanged);

//		public static readonly BindableProperty FillRuleProperty = BindableProperty.Create(
//			nameof(FillRule), typeof(FillRule), typeof(Polygon), FillRule.EvenOdd, propertyChanged: OnPathChanged);

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
//			path.Close();

//			return path;
//		}

//		private static void OnPathChanged(BindableObject bindable, object oldValue, object newValue)
//		{
//			if (bindable is Polygon polygon)
//			{
//				polygon.path?.Dispose();
//				polygon.path = null;
//			}

//			OnGraphicsChanged(bindable, oldValue, newValue);
//		}
//	}
//}
