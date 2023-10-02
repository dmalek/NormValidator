namespace NormValidator;

public class LessOrEqualNorm<T> : INorm<T>
    where T : IComparable
{
    public LessOrEqualNorm<T> Then(T referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }

    private T _referenceValue = default(T);
    public bool Validate(T value)
    {
        var comparation = ((IComparable)(value)).CompareTo(_referenceValue);
        return comparation <= 0;
    }
}

public static class LessOrEqualExtensions
{
    public static IValidationContext<TValue> LessOrEqual<TValue>(this IValidationContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        context.Norm = new LessOrEqualNorm<TValue>().Then(referenceValue);
        context.Validate();
        return context;
    }
}