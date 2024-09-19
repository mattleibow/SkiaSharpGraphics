﻿//using SkiaSharp;
//using System;
//using System.ComponentModel;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.Maui.Controls.Compatibility;
//using Microsoft.Maui.Controls;
//using Microsoft.Maui;
//using SkiaSharp.Views.Maui.Controls;
//using SkiaSharp.Views.Maui;

//namespace SkiaSharpGraphics.Graphics
//{
//	[TypeConverter(typeof(PointCollectionConverter))]
//	public class PointCollection : List<Point>
//	{
//		public PointCollection()
//		{
//		}

//		public PointCollection(IEnumerable<Point> collection)
//			: base(collection)
//		{
//		}

//		public PointCollection(int capacity)
//			: base(capacity)
//		{
//		}

//		public IEnumerable<SKPoint> AsSKPointCollection()
//			=> this.Select(p => p.ToSKPoint());

//		public static bool TryParse(string value, out PointCollection pointCollection)
//		{
//			if (string.IsNullOrWhiteSpace(value))
//			{
//				pointCollection = null;
//				return false;
//			}

//			var collection = new PointCollection();

//			var points = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
//			foreach (var point in points)
//			{
//				var numbers = point.Split(new[] { ',' });
//				if (numbers.Length != 2)
//				{
//					pointCollection = null;
//					return false;
//				}

//				if (!double.TryParse(numbers[0], out double x) || !double.TryParse(numbers[1], out double y))
//				{
//					pointCollection = null;
//					return false;
//				}

//				collection.Add(new Point(x, y));
//			}

//			pointCollection = collection;
//			return true;
//		}
//	}
//}
