namespace NormValidator;

public class EqualNorm<T> : INorm<T>
    where T: IComparable
{
    public EqualNorm<T> To(T referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }

    private T? _referenceValue = default;

    public bool Validate(T value)
    {
        var comparation = ((IComparable)(value)).CompareTo(_referenceValue);
        return comparation == 0;
    }
}

public static class EqualExtensions
{
    public static NormContext<TValue> EqualTo<TValue>(this ValidationContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {
        return context.AddNorm(new EqualNorm<TValue>().To(referenceValue));
    }

    public static NormContext<TValue> EqualTo<TValue>(this NormContext<TValue> context, TValue referenceValue)
    where TValue : IComparable
    {
        return context.ValidationContext.AddNorm(new EqualNorm<TValue>().To(referenceValue));
    }
}