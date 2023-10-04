﻿namespace NormValidator;

public class NotEqualNorm<T> : INorm<T>
    where T: IComparable
{
    public NotEqualNorm<T> To(T referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }

    private T _referenceValue = default(T);

    public bool Validate(T value)
    {
        var comparation = ((IComparable)(value)).CompareTo(_referenceValue);
        return comparation != 0;
    }
}

public static class NotEqualExtensions
{
    public static IValidationContext<TValue> NotEqualTo<TValue>(this IValidationContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        context.Norm = new NotEqualNorm<TValue>().To(referenceValue);
        context.Validate();
        return context;
    }
}