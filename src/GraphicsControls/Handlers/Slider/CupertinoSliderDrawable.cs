﻿using System.Collections.Generic;

namespace Microsoft.Maui.Graphics.Controls
{
    public class CupertinoSliderDrawable : ViewDrawable<ISlider>, ISliderDrawable
	{
		const string DefaultCupertinoSliderTrackBackgroundColor = "#8E8E93";
		const string DefaultCupertinoSliderTrackProgressColor = "#007AFF";
		const string DefaultCupertinoSliderThumbColor = "#161313";

		RectangleF trackRect = new RectangleF();
		public RectangleF TrackRect => trackRect;

		RectangleF touchTargetRect = new RectangleF(0, 0, 44, 44);
		public RectangleF TouchTargetRect => touchTargetRect;

		public override void DrawBackground(ICanvas canvas, RectangleF dirtyRect, IView view)
		{
			canvas.SaveState();

			canvas.FillColor = VirtualView.MaximumTrackColor.WithDefault(DefaultCupertinoSliderTrackBackgroundColor);

			var x = dirtyRect.X;

			var width = dirtyRect.Width;
			var height = 1;

			var y = (float)((dirtyRect.Height - height) / 2);

			trackRect.X = x;
			trackRect.Width = width;

			canvas.FillRoundedRectangle(x, y, width, height, 20);

			canvas.RestoreState();
		}

		public virtual void DrawTrackProgress(ICanvas canvas, RectangleF dirtyRect, ISlider view)
		{
			canvas.SaveState();

			canvas.FillColor = VirtualView.MinimumTrackColor.WithDefault(VirtualView.IsEnabled ? DefaultCupertinoSliderTrackProgressColor : Cupertino.Color.SystemGray.Light.InactiveGray);

			var x = dirtyRect.X;

			var value = (VirtualView.Value / VirtualView.Maximum - VirtualView.Minimum).Clamp(0, 1);
			var width = (float)(dirtyRect.Width * value);

			var height = 1;

			var y = (float)((dirtyRect.Height - height) / 2);

			canvas.FillRoundedRectangle(x, y, width, height, 20);

			canvas.RestoreState();
		}

		public virtual void DrawThumb(ICanvas canvas, RectangleF dirtyRect, ISlider view)
		{
			canvas.SaveState();

			float size = 28f;
			float strokeWidth = 0.5f;

			canvas.StrokeColor = VirtualView.ThumbColor.WithDefault(DefaultCupertinoSliderThumbColor);
			canvas.StrokeSize = strokeWidth;

			var value = (VirtualView.Value / VirtualView.Maximum - VirtualView.Minimum).Clamp(0, 1);
			var x = (float)((dirtyRect.Width * value) - (size / 2));

			if (x <= strokeWidth)
				x = strokeWidth;

			if (x >= dirtyRect.Width - (size + strokeWidth))
				x = dirtyRect.Width - (size + strokeWidth);

			var y = (float)((dirtyRect.Height - size) / 2);

			canvas.FillColor = VirtualView.ThumbColor.WithDefault(VirtualView.IsEnabled ? Cupertino.Color.Background.Light.Primary : Cupertino.Color.SystemGray.Light.InactiveGray);

			canvas.SetShadow(new SizeF(1, 1), 2, CanvasDefaults.DefaultShadowColor);

			touchTargetRect.Center(new PointF(x, y));

			canvas.FillEllipse(x, y, size, size);
			canvas.DrawEllipse(x, y, size, size);

			canvas.RestoreState();
		}

		public virtual void DrawText(ICanvas canvas, RectangleF dirtyRect, ISlider text)
        {

        }

		public override Size GetDesiredSize(IView view, double widthConstraint, double heightConstraint) =>
			new Size(widthConstraint, 36f);
	}
}