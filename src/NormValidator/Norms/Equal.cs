namespace NormValidator.Norms;

public class Equal<T> : INorm<T>
    where T: IComparable
{
    public Equal<T> To(T referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }

    private T _referenceValue = default(T);

    public bool Validate(T value)
    {
        var comparation = ((IComparable)(value)).CompareTo(_referenceValue);
        return comparation == 0;
    }
}

public static class EqualExtensions
{
    public static IValidationContext<TValue> EqualTo<TValue>(this IValidationContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        context.Norm = new Norms.Equal<TValue>().To(referenceValue);
        context.Validate();
        return context;
    }
}