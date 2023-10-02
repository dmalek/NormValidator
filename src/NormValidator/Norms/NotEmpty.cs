namespace NormValidator.Norms;

public sealed class NotEmpty : INorm<string>
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
        context.Norm = new Norms.NotEmpty();
        context.Validate();
        return context;
    }
}