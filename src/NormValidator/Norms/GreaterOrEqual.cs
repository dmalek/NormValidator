namespace NormValidator.Norms;

public class GreaterOrEqual<T> : INorm<T>
    where T : IComparable
{
    private T _referenceValue = default(T);

    public GreaterOrEqual<T> Then(T referenceValue)
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
        context.Norm = new Norms.GreaterOrEqual<TValue>().Then(referenceValue);
        context.Validate();
        return context;
    }
}