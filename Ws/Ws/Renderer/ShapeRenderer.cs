using System.Collections.Generic;
using Ws.Models;
using Ws.Renderer;

namespace Ws.Renderer
{
    public class ShapeRenderer
    {
        private readonly CanvasController _canvasController;

        public ShapeRenderer(CanvasController canvasController)
        {
            _canvasController = canvasController;
        }

        public void RenderShapes(IEnumerable<ShapeBase> shapes)
        {
            _canvasController.Clear();

            foreach (var shape in shapes)
            {
                var shapeElement = shape.CreateShapeElement(_canvasController.CanvasHeight);
                _canvasController.AddShape(shapeElement);
            }

           // _canvasController.ScaleToFit();
        }
    }
}
