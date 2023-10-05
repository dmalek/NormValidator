namespace NormValidator;

public static class Extensions
{
    public static void Throw(this Fault fault)
    {
        throw new FaultException(fault);
    }

    public static ValidationContext<TValue> WithFault<TValue>(this ValidationContext<TValue> context, FaultType faultType)
    {
        context.FaultType = faultType;
        return context;
    }

    public static ValidationContext<TValue> WithMessage<TValue>(this ValidationContext<TValue> context, string message)
    {
        context.Message = message;
        return context;
    }

    public static ValidationContext<TValue> Validate<TValue>(this ValidationResult result, TValue value)
    {
        return new ValidationContext<TValue>(result, value);
    }
}
