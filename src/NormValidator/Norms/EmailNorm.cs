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
    public static NormContext<string> Email<TValue>(this ValidationContext<string> context)
        where TValue : IComparable
    {        
        return context.AddNorm( new EmailNorm());
    }

    public static NormContext<string> Email<TValue>(this NormContext<string> context)
    where TValue : IComparable
    {
        return context.ValidationContext.AddNorm(new EmailNorm());
    }
}