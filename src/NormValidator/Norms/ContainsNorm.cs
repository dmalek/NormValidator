namespace NormValidator;

public class ContainsNorm<T> : INorm<IEnumerable<T>>
{
    public ContainsNorm<T> Contains(T referenceValule)
    {
        _referenceValue = referenceValule;
        return this;
    }

    private T _referenceValue = default(T);

    public bool Validate(IEnumerable<T> value)
    {
        return value.Contains(_referenceValue);
    }
}

public static class ContainsExtensions
{
    public static NormContext<IEnumerable<TValue>> Contains<TValue>(this ValidationContext<IEnumerable<TValue>> context, TValue referenceValue)
    {
        return context.AddNorm(new ContainsNorm<TValue>().Contains(referenceValue));
    }

    public static NormContext<IEnumerable<TValue>> Contains<TValue>(this NormContext<IEnumerable<TValue>> context, TValue referenceValue)
    {
        return context.ValidationContext.AddNorm(new ContainsNorm<TValue>().Contains(referenceValue));
    }

}

