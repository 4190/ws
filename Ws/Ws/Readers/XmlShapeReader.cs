using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Ws.Models;
using Ws.Renderer;

namespace Ws.Readers
{
    public class XmlShapeReader : IShapeReader
    {
        public List<ShapeBase> ReadShapes(string filePath)
        {
            var shapes = new List<ShapeBase>();
            var document = XDocument.Load(filePath);

            foreach (XElement element in document.Descendants("Shape"))
            {
                shapes.Add(ShapeFactory.CreateShape(element));
            }

            return shapes;
        }
    }
}
