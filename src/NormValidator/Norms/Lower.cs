namespace NormValidator.Norms;

public class Lower<T> : INorm<T>
    where T: IComparable
{
    public Lower<T> Then(T referenceValue)
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

public static class LowerExtensions
{
    public static IValidationContext<TValue> Lower<TValue>(this IValidationContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        context.Norm = new Norms.Lower<TValue>().Then(referenceValue);
        context.Validate();
        return context;
    }
}
