namespace NormValidator.Norms;

public class Greater<T> : INorm<T>
    where T : IComparable
{
    public Greater<T> Then(T referenceValue)
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
    public static IValidationContext<TValue> GreaterThen<TValue>(this IValidationContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        context.Norm = new Norms.Greater<TValue>().Then(referenceValue);
        context.Validate();
        return context;
    }
}