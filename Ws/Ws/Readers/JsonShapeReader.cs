using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Ws.Models;
using Ws.Renderer;

namespace Ws.Readers
{
    public class JsonShapeReader : IShapeReader
    {
        public List<ShapeBase> ReadShapes(string filePath)
        {
            var shapes = new List<ShapeBase>();
            var json = File.ReadAllText(filePath);
            var jsonElements = JsonSerializer.Deserialize<List<JsonElement>>(json);

            foreach (var element in jsonElements)
            {
                shapes.Add(ShapeFactory.CreateShape(element));
            }

            return shapes;
        }
    }
}
