namespace NormValidator.Norms;

public class Less<T> : INorm<T>
    where T : IComparable
{
    public Less<T> Then(T referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }

    private T _referenceValue = default(T);
    public bool Validate(T value)
    {
        var comparation = ((IComparable)(value)).CompareTo(_referenceValue);
        return comparation < 0;
    }
}

public static class LessExtensions
{
    public static IValidationContext<TValue> LessThen<TValue>(this IValidationContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        context.Norm = new Norms.Less<TValue>().Then(referenceValue);
        context.Validate();
        return context;
    }
}