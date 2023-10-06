namespace NormValidator;

public class GreaterOrEqualNorm<T> : INorm<T>
    where T : IComparable
{
    private T _referenceValue = default(T);

    public GreaterOrEqualNorm<T> Then(T referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }
            
    public bool Validate(T value)
    {
        var comparation = ((IComparable)(value)).CompareTo(_referenceValue);
        return comparation >= 0;
    }
}

public static class GreaterOrEqualExtensions
{
    public static NormContext<TValue> GreaterOrEqualTo<TValue>(this ValidationContext<TValue> context, TValue referenceValue)
    where TValue : IComparable
    {
        return context.AddNorm(new GreaterOrEqualNorm<TValue>().Then(referenceValue));
    }

    public static NormContext<TValue> GreaterOrEqualTo<TValue>(this NormContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        return context.ValidationContext.AddNorm(new GreaterOrEqualNorm<TValue>().Then(referenceValue));
    }
}