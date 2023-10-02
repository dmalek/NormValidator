namespace NormValidator.Norms;

public class NotIn<T> : INorm<T>
{
    public NotIn<T> Values(params T[] referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }
    
    private T[] _referenceValue = new T[] { };

    public bool Validate(T value)
    {            
        return !_referenceValue.Contains(value);
    }
}

public static class NotInExtensions
{
    public static IValidationContext<TValue> NotIn<TValue>(this IValidationContext<TValue> context, params TValue[] referenceValue)
    {        
        context.Norm = new Norms.NotIn<TValue>().Values(referenceValue);
        context.Validate();
        return context;
    }
}