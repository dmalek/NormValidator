namespace NormValidator;

public sealed class NotEmptyNorm : INorm<string>
{
    public bool Validate(string value)
    {
        if (value == null || value.Length == 0)
        {
            return false;
        }

        return true;
    }
}


public static class NotEmptyExtensions
{
    public static NormContext<string> NotEmpty(this ValidationContext<string> context)
    {
        return context.AddNorm(new NotEmptyNorm());
    }

    public static NormContext<string> NotEmpty(this NormContext<string> context)
    {        
        return context.ValidationContext.AddNorm(new NotEmptyNorm());
    }
}