using System.Text.Json;
using System.Xml.Linq;
using Ws.Models;

namespace Ws.Parser
{
    public interface IJsonShapeParser
    {
        ShapeBase ParseShape(JsonElement element);
    }

    public interface IXmlShapeParser
    {
        ShapeBase ParseShape(XElement element);
    }
}
