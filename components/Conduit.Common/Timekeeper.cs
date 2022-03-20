namespace Conduit.Common;

public class Timekeeper : ITimekeeper
{
    public DateTimeOffset Now { get; } = DateTimeOffset.Now;
}