﻿namespace SkiaSharpGraphics;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnClick(object sender, EventArgs e)
	{
		//var s = gradientRect.Left;
		//this.Animate("test", value =>
		//{
		//	pinkLine.StrokeThickness = value * 20;

		//	gradientRect.Left = s + (value * 200);
		//}, length: 1000, easing: Easing.CubicInOut);


		//innerEllipse.Width = 200;


		if (pinkLine.Stroke is Graphics.SolidColorBrush pinkBrush)
		{
			pinkBrush.Color = Colors.Maroon;
		}
	}
}

