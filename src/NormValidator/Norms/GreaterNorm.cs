﻿namespace NormValidator;

public class GreaterNorm<T> : INorm<T>
    where T : IComparable
{
    public GreaterNorm<T> Then(T referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }


    private T _referenceValue = default(T);

    public bool Validate(T value)
    {
        var comparation = ((IComparable)(value)).CompareTo(_referenceValue);
        return comparation > 0;
    }
}

public static class GreaterExtensions
{
    public static IValidationContext<TValue> GreaterThen<TValue>(this IValidationContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        context.Norm = new GreaterNorm<TValue>().Then(referenceValue);
        context.Validate();
        return context;
    }
}