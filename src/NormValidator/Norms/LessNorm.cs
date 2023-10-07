﻿namespace NormValidator;

public class LessNorm<T> : INorm<T>
    where T : IComparable
{
    public LessNorm<T> Then(T referenceValue)
    {
        _referenceValue = referenceValue;
        return this;
    }

    private T? _referenceValue = default;
    public bool Validate(T value)
    {
        var comparation = ((IComparable)(value)).CompareTo(_referenceValue);
        return comparation < 0;
    }
}

public static class LessExtensions
{
    public static NormContext<TValue> LessThen<TValue>(this ValidationContext<TValue> context, TValue referenceValue)
    where TValue : IComparable
    {
        return context.AddNorm(new LessNorm<TValue>().Then(referenceValue));
    }

    public static NormContext<TValue> LessThen<TValue>(this NormContext<TValue> context, TValue referenceValue)
        where TValue : IComparable
    {        
        return context.ValidationContext.AddNorm(new LessNorm<TValue>().Then(referenceValue));        
    }
}