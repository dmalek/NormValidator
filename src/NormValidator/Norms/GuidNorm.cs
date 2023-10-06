namespace NormValidator;

public class GuidNorm : INorm<string>
{
    public bool Validate(string value)
    {
        return System.Guid.TryParse(value, out var guid);
    }
}

public static class GuidExtensions
{
    public static NormContext<string> Guid<TValue>(this ValidationContext<string> context)
    where TValue : IComparable
    {
        return context.AddNorm(new GuidNorm());
    }

    public static NormContext<string> Guid<TValue>(this NormContext<string> context)
        where TValue : IComparable
    {
        return context.ValidationContext.AddNorm(new GuidNorm());
    }
}