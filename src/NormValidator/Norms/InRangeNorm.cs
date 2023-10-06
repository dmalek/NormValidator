namespace NormValidator;

public class InRangeNorm<T> : INorm<T>
    where T : IComparable
{
    public InRangeNorm<T> From(T referenceValue)
    {
        _from = referenceValue;
        return this;
    }

    public InRangeNorm<T> To(T referenceValue)
    {
        _to = referenceValue;
        return this;
    }

    private T _from = default(T);
    private T _to = default(T);

    public bool Validate(T value)
    {
        var lesThenFrom = ((IComparable)(value)).CompareTo(_from) < 0;
        var greaterThenTo = ((IComparable)(value)).CompareTo(_to) > 0;

        return lesThenFrom && greaterThenTo;
    }
}

public static class InRangeExtensions
{
    public static NormContext<TValue> InRange<TValue>(this ValidationContext<TValue> context, TValue from, TValue to)
        where TValue : IComparable
    {
        return context.AddNorm(new InRangeNorm<TValue>().From(from).To(to));
    }

    public static NormContext<TValue> InRange<TValue>(this NormContext<TValue> context, TValue from, TValue to)
    where TValue : IComparable
    {
        return context.ValidationContext.AddNorm(new InRangeNorm<TValue>().From(from).To(to));
    }
}