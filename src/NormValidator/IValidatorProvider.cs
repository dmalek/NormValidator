namespace NormValidator;

public interface IValidatorProvider
{
    Task<ValidationResult> ValidateAsync<T>(T data, CancellationToken cancellationToken = default) where T : class;

    Task<ValidationResult> TryToValidateAsync<T>(T data, CancellationToken cancellationToken = default) where T : class;

    IValidationHandler<T>? GetValidator<T>(T data) where T : class;

    IValidationHandler<T>? GetRequiredValidator<T>(T data) where T : class;
}
