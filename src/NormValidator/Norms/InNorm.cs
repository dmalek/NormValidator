namespace NormValidator;

public class InNorm<T> : INorm<T>  
{        
    public InNorm<T> Values(params T[] referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }
    
    private T[] _referenceValue = new T[] { };
    public bool Validate(T value)
    {            
        return _referenceValue.Contains(value);
    }
}

public static class InExtensions
{
    public static IValidationContext<TValue> In<TValue>(this IValidationContext<TValue> context, params TValue[] referenceValue)
    {        
        context.Norm = new InNorm<TValue>().Values(referenceValue);
        context.Validate();
        return context;
    }
}

