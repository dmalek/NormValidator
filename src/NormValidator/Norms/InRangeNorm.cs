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
    public static IValidationContext<TValue> LessThen<TValue>(this IValidationContext<TValue> context, TValue from, TValue to)
        where TValue : IComparable
    {        
        context.Norm = new InRangeNorm<TValue>().From(from).To(to);
        context.Validate();
        return context;
    }
}