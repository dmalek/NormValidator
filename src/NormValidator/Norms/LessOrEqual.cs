namespace NormValidator.Norms;

public class LessOrEqual<T> : INorm<T>
    where T : IComparable
{
    public LessOrEqual<T> Then(T referenceValue)
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
        context.Norm = new Norms.LessOrEqual<TValue>().Then(referenceValue);
        context.Validate();
        return context;
    }
}