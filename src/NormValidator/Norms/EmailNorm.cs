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
    public static IValidationContext<string> Email<TValue>(this IValidationContext<string> context)
        where TValue : IComparable
    {        
        context.Norm = new EmailNorm();
        context.Validate();
        return context;
    }
}