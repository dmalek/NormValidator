using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NormValidator;

public class DataAnnotationsNorm<T> : INorm<T>, INormErrors
{
    public IEnumerable<string?> Errors { get; set; } = Enumerable.Empty<string?>();
    
    public bool Validate(T value)
    {
        var context = new ValidationContext(value);
        ICollection<System.ComponentModel.DataAnnotations.ValidationResult> errors = new Collection<System.ComponentModel.DataAnnotations.ValidationResult>();
        var isValid = Validator.TryValidateObject(value, context, errors, true);

        if (errors !=  null && errors.Count > 0)
        {
            Errors = errors.Select(x => x.ErrorMessage).ToList().AsEnumerable();
        }
        else
        {
            Errors = Enumerable.Empty<string?>();
        }
        
        return isValid;
    }
}

public static class DataAnnotationsExtensions
{
    public static IValidationContext<TValue> DataAnnotations<TValue>(this IValidationContext<TValue> context)
    {        
        context.Norm = new DataAnnotationsNorm<TValue>();        
        context.Validate();
        return context;
    }
}