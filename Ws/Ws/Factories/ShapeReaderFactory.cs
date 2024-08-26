using System;
using Ws.Readers;

namespace Ws.Factories
{
    public static class ShapeReaderFactory
    {
        public static IShapeReader CreateShapeReader(string format)
        {
            switch (format.ToLower())
            {
                case "json":
                    return new JsonShapeReader();
                case "xml":
                    return new XmlShapeReader();
                default:
                    throw new NotSupportedException($"Format '{format}' is not supported.");
            }
        }
    }
}
