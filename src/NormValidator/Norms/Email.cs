using System.ComponentModel.DataAnnotations;

namespace NormValidator.Norms;

public class Email : INorm<string>    
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
        context.Norm = new Norms.Email();
        context.Validate();
        return context;
    }
}