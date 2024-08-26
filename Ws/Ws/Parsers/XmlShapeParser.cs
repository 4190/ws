using System;
using System.Linq;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Media;
using Ws.Models;
using System.Text.Json;
using System.Runtime.InteropServices;

namespace Ws.Parser
{
    public class XmlShapeParser : IShapeParser
    {
        public ShapeBase ParseShape(XElement element)
        {
            string type = element.Attribute("type").Value;

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

        public ShapeBase ParseShape(JsonElement element)
        {
            throw new NotSupportedException("XML parser cannot handle JSON elements.");
        }

        private Line ParseLine(XElement element)
        {
            return new Line
            {
                A = ParsePoint(element.Element("a").Value),
                B = ParsePoint(element.Element("b").Value),
                Color = ParseColor(element.Element("color").Value)
            };
        }

        private Circle ParseCircle(XElement element)
        {
            return new Circle
            {
                Center = ParsePoint(element.Element("center").Value),
                Radius = double.Parse(element.Element("radius").Value, System.Globalization.CultureInfo.InvariantCulture),
                IsFilled = bool.Parse(element.Element("filled").Value),
                Color = ParseColor(element.Element("color").Value)
            };
        }

        private Triangle ParseTriangle(XElement element)
        {
            return new Triangle
            {
                A = ParsePoint(element.Element("a").Value),
                B = ParsePoint(element.Element("b").Value),
                C = ParsePoint(element.Element("c").Value),
                IsFilled = bool.Parse(element.Element("filled").Value),
                Color = ParseColor(element.Element("color").Value)
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
