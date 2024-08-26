using System;
using System.Linq;
using System.Text.Json;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;
using Ws.Models;

namespace Ws.Parser
{
    public class JsonShapeParser : IShapeParser
    {
        public ShapeBase ParseShape(JsonElement element)
        {
            string type = element.GetProperty("type").GetString();

            if (type == "line")
            {
                return ParseLine(element);
            }
            else if (type == "circle")
            {
                return ParseCircle(element);
            }
            else if (type == "triangle")
            {
                return ParseTriangle(element);
            }
            else
            {
                throw new NotSupportedException($"Shape type '{type}' is not supported.");
            }
        }

        public ShapeBase ParseShape(XElement element)
        {
            throw new NotSupportedException("JSON parser cannot handle XML elements.");
        }

        private Line ParseLine(JsonElement element)
        {
            return new Line
            {
                A = ParsePoint(element.GetProperty("a").GetString()),
                B = ParsePoint(element.GetProperty("b").GetString()),
                Color = ParseColor(element.GetProperty("color").GetString())
            };
        }

        private Circle ParseCircle(JsonElement element)
        {
            return new Circle
            {
                Center = ParsePoint(element.GetProperty("center").GetString()),
                Radius = element.GetProperty("radius").GetDouble(),
                IsFilled = element.GetProperty("filled").GetBoolean(),
                Color = ParseColor(element.GetProperty("color").GetString())
            };
        }

        private Triangle ParseTriangle(JsonElement element)
        {
            return new Triangle
            {
                A = ParsePoint(element.GetProperty("a").GetString()),
                B = ParsePoint(element.GetProperty("b").GetString()),
                C = ParsePoint(element.GetProperty("c").GetString()),
                IsFilled = element.GetProperty("filled").GetBoolean(),
                Color = ParseColor(element.GetProperty("color").GetString())
            };
        }

        private Point ParsePoint(string pointString)
        {
            var parts = pointString.Split(';').Select(s => s.Trim()).ToArray();
            return new Point(
                double.Parse(parts[0]),
                double.Parse(parts[1]));
        }

        private Color ParseColor(string colorString)
        {
            var parts = colorString.Split(';').Select(s => byte.Parse(s)).ToArray();
            return Color.FromArgb(parts[0], parts[1], parts[2], parts[3]);
        }
    }
}
