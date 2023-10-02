namespace NormValidator.Norms;

public class In<T> : INorm<T>  
{        
    public In<T> Values(params T[] referenceValue)
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
        context.Norm = new Norms.In<TValue>().Values(referenceValue);
        context.Validate();
        return context;
    }
}

