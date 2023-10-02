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
    public static IValidationContext<string> Guid<TValue>(this IValidationContext<string> context)
        where TValue : IComparable
    {
        context.Norm = new GuidNorm();
        context.Validate();
        return context;
    }
}