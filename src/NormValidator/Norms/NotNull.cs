namespace NormValidator.Norms;

public sealed class NotNull<T> : INorm<T>
{
    public bool Validate(T value)
    {
        return value != null;
    }
}

public static class NotNullExtensions
{
    public static IValidationContext<TValue> Lower<TValue>(this IValidationContext<TValue> context)
        where TValue : IComparable
    {        
        context.Norm = new Norms.NotNull<TValue>();
        context.Validate();
        return context;
    }
}