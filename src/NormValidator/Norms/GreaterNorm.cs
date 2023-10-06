namespace NormValidator;

public class GreaterNorm<T> : INorm<T>
    where T : IComparable
{
    public GreaterNorm<T> Then(T referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }


    private T _referenceValue = default(T);

    public bool Validate(T value)
    {
        var comparation = ((IComparable)(value)).CompareTo(_referenceValue);
        return comparation > 0;
    }
}

public static class GreaterExtensions
{
    public static NormContext<TValue> GreaterThen<TValue>(this ValidationContext<TValue> context, TValue referenceValue)
    where TValue : IComparable
    {
        return context.AddNorm(new GreaterNorm<TValue>().Then(referenceValue));
    }
    public static NormContext<TValue> GreaterThen<TValue>(this NormContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {
        return context.ValidationContext.AddNorm(new GreaterNorm<TValue>().Then(referenceValue));
    }
}