﻿namespace Microsoft.Maui.Graphics.Controls
{
    public class MaterialDatePickerDrawable : ViewDrawable<IDatePicker>, IDatePickerDrawable
    {
        public void DrawBackground(ICanvas canvas, RectangleF dirtyRect, IDatePicker datePicker)
        {
            canvas.SaveState();

            if (datePicker.Background != null)
                canvas.SetFillPaint(datePicker.Background, dirtyRect);
            else
                canvas.FillColor = datePicker.IsEnabled ? Material.Color.Gray5.ToColor() : Material.Color.Gray3.ToColor();

            const float cornerRadius = 4.0f;

            var x = dirtyRect.X;
            var y = dirtyRect.Y;

            var height = dirtyRect.Height;
            var width = dirtyRect.Width;

            canvas.FillRoundedRectangle(x, y, width, height, cornerRadius, cornerRadius, 0, 0);

            canvas.RestoreState();
        }

        public void DrawBorder(ICanvas canvas, RectangleF dirtyRect, IDatePicker datePicker)
        {
            canvas.SaveState();

            var strokeWidth = 1.0f;
            canvas.FillColor = Material.Color.Black.ToColor();

            var x = dirtyRect.X;
            var y = 53.91f;

            var width = dirtyRect.Width;
            var height = strokeWidth;

            canvas.FillRectangle(x, y, width, height);

            canvas.RestoreState();
        }

        public void DrawDate(ICanvas canvas, RectangleF dirtyRect, IDatePicker datePicker)
        {
            canvas.SaveState();

            canvas.FontColor = datePicker.TextColor.WithDefault(Material.Color.Dark);
            canvas.FontSize = 16f;

            float margin = 12f;

            var horizontalAlignment = HorizontalAlignment.Left;

            var x = dirtyRect.X + margin;

            var height = dirtyRect.Height;
            var width = dirtyRect.Width;

            var date = datePicker.Date;

            canvas.DrawString(date.ToShortDateString(), x, 22f, width - margin, height, horizontalAlignment, VerticalAlignment.Top);

            canvas.RestoreState();
        }

        public void DrawIndicator(ICanvas canvas, RectangleF dirtyRect, IDatePicker datePicker)
        {

        }

        public void DrawPlaceholder(ICanvas canvas, RectangleF dirtyRect, IDatePicker datePicker)
        {
            canvas.SaveState();

            if (datePicker.TextColor == null)
                canvas.FontColor = Material.Color.Gray1.ToColor();
            else
                canvas.FontColor = datePicker.TextColor.WithAlpha(0.75f);

            canvas.FontSize = 12f;

            float margin = 12f;

            var horizontalAlignment = HorizontalAlignment.Left;

            var x = dirtyRect.X + margin;

            var height = dirtyRect.Height;
            var width = dirtyRect.Width;

            canvas.DrawString("Date", x, 6f, width - margin, height, horizontalAlignment, VerticalAlignment.Top);

            canvas.RestoreState();
        }

        public override Size GetDesiredSize(IView view, double widthConstraint, double heightConstraint) =>
            new Size(widthConstraint, 56f);
    }
}
