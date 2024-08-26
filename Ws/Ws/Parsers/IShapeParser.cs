using System.Text.Json;
using System.Xml.Linq;
using Ws.Models;

namespace Ws.Parser
{
    public interface IShapeParser
    {
        ShapeBase ParseShape(JsonElement element);
        ShapeBase ParseShape(XElement element);
    }
}
