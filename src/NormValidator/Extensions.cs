namespace NormValidator;

public static class Extensions
{
    public static void Throw<T>(this Fault<T> fault)
    {
        throw new FaultException<T>(fault);
    }

    public static ValidationContext<TValue, TFault> WithFault<TValue, TFault>(this ValidationContext<TValue, TFault> context, TFault fault)
    {
        context.Fault = fault;
        return context;
    }

    public static ValidationContext<TValue, TFault> WithMessage<TValue, TFault>(this ValidationContext<TValue, TFault> context, string message)
    {
        context.Message = message;
        return context;
    }

    public static ValidationContext<TValue, TFault> Validate<TValue, TFault>(this ValidationResult<TFault> result, TValue value)
    {
        return new ValidationContext<TValue, TFault>(result, value);
    }
}
