using System.Windows;
using System.Windows.Controls;

namespace Ws.Renderer
{
    public class CanvasController
    {
        private readonly Canvas _canvas;
        public double CanvasHeight => _canvas.ActualHeight;
        public double CanvasWidth => _canvas.ActualWidth;

        public CanvasController(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void AddShape(UIElement shapeElement)
        {
            _canvas.Children.Add(shapeElement);
        }

        public void Clear()
        {
            _canvas.Children.Clear();
        }

        public void ScaleToFit()
        {
            if (_canvas.Children.Count == 0) return;

            double minX = double.MaxValue, minY = double.MaxValue;
            double maxX = double.MinValue, maxY = double.MinValue;

            foreach (UIElement element in _canvas.Children)
            {
                if (element is FrameworkElement shape)
                {
                    double left = Canvas.GetLeft(shape);
                    double top = Canvas.GetTop(shape);
                    double right = left + shape.ActualWidth;
                    double bottom = top + shape.ActualHeight;

                    minX = System.Math.Min(minX, left);
                    minY = System.Math.Min(minY, top);
                    maxX = System.Math.Max(maxX, right);
                    maxY = System.Math.Max(maxY, bottom);
                }
            }

            double contentWidth = maxX - minX;
            double contentHeight = maxY - minY;

            double scaleX = CanvasWidth / contentWidth;
            double scaleY = CanvasHeight / contentHeight;

            double scale = System.Math.Min(scaleX, scaleY);

            // Apply scaling transform to fit the shapes within the canvas
            _canvas.RenderTransform = new System.Windows.Media.ScaleTransform(scale, scale);

            // Center the content on the canvas
            _canvas.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
        }
    }
}
