namespace NormValidator;

public class LowerNorm<T> : INorm<T>
    where T: IComparable
{
    public LowerNorm<T> Then(T referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }

    private T? _referenceValue = default;

    public bool Validate(T value)
    {
        var comparation = ((IComparable)(value)).CompareTo(_referenceValue);
        return comparation < 0;
    }
}

public static class LowerExtensions
{
    public static NormContext<TValue> Lower<TValue>(this ValidationContext<TValue> context, TValue referenceValue)
    where TValue : IComparable
    {
        return context.AddNorm(new LowerNorm<TValue>().Then(referenceValue));
    }

    public static NormContext<TValue> Lower<TValue>(this NormContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        return context.ValidationContext.AddNorm(new LowerNorm<TValue>().Then(referenceValue));
    }
}
