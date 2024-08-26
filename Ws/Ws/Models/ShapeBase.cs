using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ws.Models
{
    public abstract class ShapeBase
    {
        public Color Color { get; set; }
        public bool IsFilled { get; set; }

        public abstract UIElement CreateShapeElement(double canvasHeight);

        protected Point FlipYAxis(Point point, double canvasHeight)
        {
            return new Point(point.X, canvasHeight - point.Y);
        }
    }
}
