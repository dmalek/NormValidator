namespace NormValidator;

public class NotInNorm<T> : INorm<T>
{
    public NotInNorm<T> Values(params T[] referenceValue)
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
        context.Norm = new NotInNorm<TValue>().Values(referenceValue);
        context.Validate();
        return context;
    }
}