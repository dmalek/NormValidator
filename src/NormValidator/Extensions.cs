namespace NormValidator;

public static class Extensions
{
    public static void Throw(this Fault fault)
    {
        throw new FaultException(fault);
    }

    public static ValidationContext<TValue> WithDefaultFault<TValue>(this ValidationContext<TValue> context, FaultType faultType)
    {
        context.DefaultFaultType = faultType;
        return context;
    }

    public static ValidationContext<TValue> WithDefaultMessage<TValue>(this ValidationContext<TValue> context, string message)
    {
        context.DefaultMessage = message;
        return context;
    }

    public static NormContext<TValue> WithFault<TValue>(this NormContext<TValue> context, FaultType faultType)
    {
        context.FaultType = faultType;
        return context;
    }

    public static NormContext<TValue> WithMessage<TValue>(this NormContext<TValue> context, string message)
    {
        context.Message = message;
        return context;
    }
}
