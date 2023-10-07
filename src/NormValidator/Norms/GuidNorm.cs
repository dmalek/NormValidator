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
    public static NormContext<string> Guid(this ValidationContext<string> context)
    {
        return context.AddNorm(new GuidNorm());
    }

    public static NormContext<string> Guid(this NormContext<string> context)
    {
        return context.ValidationContext.AddNorm(new GuidNorm());
    }
}