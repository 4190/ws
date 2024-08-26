using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace Ws.Models
{
    public class Line : ShapeBase
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public override UIElement CreateShapeElement(double canvasHeight)
        {
            var line = new System.Windows.Shapes.Line
            {
                X1 = A.X,
                Y1 = FlipYAxis(A, canvasHeight).Y,
                X2 = B.X,
                Y2 = FlipYAxis(B, canvasHeight).Y,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1
            };

            return line;
        }
    }
}
