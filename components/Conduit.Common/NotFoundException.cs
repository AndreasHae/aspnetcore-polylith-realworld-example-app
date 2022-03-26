using System.Runtime.Serialization;

namespace Conduit.Common;

[Serializable]
public class NotFoundException : Exception
{
    public NotFoundException(string entity, Exception? innerException = null) : base(MessageFor(entity), innerException)
    {
    }

    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    private static string MessageFor(string entity)
    {
        return $"{entity} could not be found";
    }
}