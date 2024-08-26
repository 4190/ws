using System;
using System.Text.Json;
using System.Xml.Linq;
using Ws.Models;
using Ws.Parser;
using Ws.Renderer;

namespace Ws.Factories
{
    public class CircleFactory : IShapeFactory
    {
        private readonly JsonShapeParser _jsonParser = new JsonShapeParser();
        private readonly XmlShapeParser _xmlParser = new XmlShapeParser();

        public ShapeBase CreateShape(JsonElement element)
        {
            // Using the JsonShapeParser to parse the shape
            return _jsonParser.ParseShape(element);
        }

        public ShapeBase CreateShape(XElement element)
        {
            // Using the XmlShapeParser to parse the shape
            return _xmlParser.ParseShape(element);
        }
    }
}
