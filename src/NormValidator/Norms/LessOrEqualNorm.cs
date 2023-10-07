namespace NormValidator;

public class LessOrEqualNorm<T> : INorm<T>
    where T : IComparable
{
    public LessOrEqualNorm<T> Then(T referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }

    private T? _referenceValue = default;
    public bool Validate(T value)
    {
        var comparation = ((IComparable)(value)).CompareTo(_referenceValue);
        return comparation <= 0;
    }
}

public static class LessOrEqualExtensions
{
    public static NormContext<TValue> LessOrEqual<TValue>(this ValidationContext<TValue> context, TValue referenceValue)
    where TValue : IComparable
    {
        return context.AddNorm(new LessOrEqualNorm<TValue>().Then(referenceValue));
    }

    public static NormContext<TValue> LessOrEqual<TValue>(this NormContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        return context.ValidationContext.AddNorm(new LessOrEqualNorm<TValue>().Then(referenceValue));
    }
}