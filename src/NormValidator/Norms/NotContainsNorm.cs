﻿namespace NormValidator;

public class NotContainsNorm<T> : INorm<IEnumerable<T>>
{
    public NotContainsNorm<T> Contains(T referenceValule)
    {
        _referenceValue = referenceValule;
        return this;
    }

    private T? _referenceValue = default;

    public bool Validate(IEnumerable<T> value)
    {
        return !value.Contains(_referenceValue);
    }
}

public static class NotContainsNormExtensions
{
    public static NormContext<IEnumerable<TValue>> NotContains<TValue>(this ValidationContext<IEnumerable<TValue>> context, TValue referenceValue)
    {
        return context.AddNorm(new NotContainsNorm<TValue>().Contains(referenceValue));
    }

    public static NormContext<IEnumerable<TValue>> NotContains<TValue>(this NormContext<IEnumerable<TValue>> context, TValue referenceValue)
    {
        return context.ValidationContext.AddNorm(new NotContainsNorm<TValue>().Contains(referenceValue));
    }

}

