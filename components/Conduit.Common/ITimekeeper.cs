namespace Conduit.Common;

public interface ITimekeeper
{
    DateTimeOffset Now { get; }
}