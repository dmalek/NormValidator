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
    public static NormContext<TValue> NotIn<TValue>(this ValidationContext<TValue> context, params TValue[] referenceValue)
    {
        return context.AddNorm(new NotInNorm<TValue>().Values(referenceValue));
    }

    public static NormContext<TValue> NotIn<TValue>(this NormContext<TValue> context, params TValue[] referenceValue)
    {        
        return context.ValidationContext.AddNorm(new NotInNorm<TValue>().Values(referenceValue));
    }
}