namespace DistributedEcomm.Core.Exceptions;

public class AggregateNotFoundException : Exception
{
    private AggregateNotFoundException()
    {
    }

    public AggregateNotFoundException(string? message) 
        : base(message)
    {
    }

    public AggregateNotFoundException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}