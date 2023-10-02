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
    public static IValidationContext<TValue> GreaterOrEqualTo<TValue>(this IValidationContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        context.Norm = new GreaterOrEqualNorm<TValue>().Then(referenceValue);
        context.Validate();
        return context;
    }
}