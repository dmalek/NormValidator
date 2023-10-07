using System.ComponentModel.DataAnnotations;

namespace NormValidator;

public class EmailNorm : INorm<string>    
{
    public bool Validate(string value)
    {
        return new EmailAddressAttribute().IsValid(value);
    }
}

public static class EmailExtensions
{
    public static NormContext<string> Email(this ValidationContext<string> context)
    {        
        return context.AddNorm( new EmailNorm());
    }

    public static NormContext<string> Email(this NormContext<string> context)
    {
        return context.ValidationContext.AddNorm(new EmailNorm());
    }
}