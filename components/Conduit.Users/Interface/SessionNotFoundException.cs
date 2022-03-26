using System.Runtime.Serialization;

namespace Conduit.Users.Interface;

[Serializable]
public class SessionNotFoundException : Exception
{
    public SessionNotFoundException()
    {
    }

    protected SessionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}