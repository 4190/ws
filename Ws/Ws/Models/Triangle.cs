using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace Ws.Models
{
    public class Triangle : ShapeBase
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public override UIElement CreateShapeElement(double canvasHeight)
        {
            var polygon = new Polygon
            {
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1,
                Points = new PointCollection
                {
                    FlipYAxis(A, canvasHeight),
                    FlipYAxis(B, canvasHeight),
                    FlipYAxis(C, canvasHeight)
                }
            };

            if (IsFilled)
            {
                polygon.Fill = new SolidColorBrush(Color);
            }

            return polygon;
        }
    }
}
