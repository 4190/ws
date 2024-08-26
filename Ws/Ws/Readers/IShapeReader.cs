using System.Collections.Generic;
using Ws.Models;

namespace Ws.Readers
{
    public interface IShapeReader
    {
        List<ShapeBase> ReadShapes(string filePath);
    }
}
