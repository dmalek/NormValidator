namespace NormValidator;

public class NotEqualNorm<T> : INorm<T>
    where T: IComparable
{
    public NotEqualNorm<T> To(T referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }

    private T _referenceValue = default(T);

    public bool Validate(T value)
    {
        var comparation = ((IComparable)(value)).CompareTo(_referenceValue);
        return comparation != 0;
    }
}

public static class NotEqualExtensions
{
    public static NormContext<TValue> NotEqualTo<TValue>(this ValidationContext<TValue> context, TValue referenceValue)
    where TValue : IComparable
    {
        return context.AddNorm(new NotEqualNorm<TValue>().To(referenceValue));
    }

    public static NormContext<TValue> NotEqualTo<TValue>(this NormContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        return context.ValidationContext.AddNorm(new NotEqualNorm<TValue>().To(referenceValue));
    }
}