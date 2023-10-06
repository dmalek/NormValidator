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
    public static NormContext<TValue> In<TValue>(this ValidationContext<TValue> context, params TValue[] referenceValue)
    {
        return context.AddNorm(new InNorm<TValue>().Values(referenceValue));
    }

    public static NormContext<TValue> In<TValue>(this NormContext<TValue> context, params TValue[] referenceValue)
    {        
        return context.ValidationContext.AddNorm(new InNorm<TValue>().Values(referenceValue));
    }
}

