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
    public static IValidationContext<string> NotEmpty(this IValidationContext<string> context)
    {        
        context.Norm = new NotEmptyNorm();
        context.Validate();
        return context;
    }
}