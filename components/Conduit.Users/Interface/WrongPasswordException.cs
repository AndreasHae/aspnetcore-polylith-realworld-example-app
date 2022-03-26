using System.Runtime.Serialization;

namespace Conduit.Users.Interface;

[Serializable]
public class WrongPasswordException : Exception
{
    public WrongPasswordException() : base("Incorrect password")
    {
    }

    protected WrongPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}