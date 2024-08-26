using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace Ws.Models
{
    public class Circle : ShapeBase
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
        public bool Filled { get; set; }

        public override UIElement CreateShapeElement(double canvasHeight)
        {
            var ellipse = new Ellipse
            {
                Width = Radius * 2,
                Height = Radius * 2,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1,
                Fill = Filled ? new SolidColorBrush(Color) : Brushes.Transparent
            };

            Canvas.SetLeft(ellipse, Center.X - Radius);
            Canvas.SetTop(ellipse, FlipYAxis(Center, canvasHeight).Y - Radius);

            return ellipse;
        }
    }
}
