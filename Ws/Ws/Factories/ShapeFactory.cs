using System;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Media;
using Ws.Models;
using Ws.Factories;

namespace Ws.Renderer
{
    public interface IShapeFactory
    {
        ShapeBase CreateShape(JsonElement element);
        ShapeBase CreateShape(XElement element);
    }

    public static class ShapeFactory
    {
        public static ShapeBase CreateShape(JsonElement element)
        {
            string type = element.GetProperty("type").GetString();

            switch (type)
            {
                case "line":
                    return new LineFactory().CreateShape(element);

                case "circle":
                    return new CircleFactory().CreateShape(element);

                case "triangle":
                    return new TriangleFactory().CreateShape(element);

                default:
                    throw new NotSupportedException($"Shape type '{type}' is not supported.");
            }
        }

        public static ShapeBase CreateShape(XElement element)
        {
            string type = element.Attribute("type").Value;

            switch (type)
            {
                case "line":
                    return new LineFactory().CreateShape(element);

                case "circle":
                    return new CircleFactory().CreateShape(element);

                case "triangle":
                    return new TriangleFactory().CreateShape(element);

                default:
                    throw new NotSupportedException($"Shape type '{type}' is not supported.");
            }
        }
    }
}
