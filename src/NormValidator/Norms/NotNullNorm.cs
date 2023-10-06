namespace NormValidator;

public sealed class NotNullNorm<T> : INorm<T>
{
    public bool Validate(T value)
    {
        return value != null;
    }
}

public static class NotNullExtensions
{
    public static NormContext<TValue> Lower<TValue>(this ValidationContext<TValue> context)
    where TValue : IComparable
    {
        return context.AddNorm(new NotNullNorm<TValue>());
    }

    public static NormContext<TValue> Lower<TValue>(this NormContext<TValue> context)
        where TValue : IComparable
    {        
        return context.ValidationContext.AddNorm(new NotNullNorm<TValue>());
    }
}