namespace NormValidator;

public interface IValidationHandler<T>
{
    Task<ValidationResult> ValidateAsync(T data, CancellationToken cancellationToken = default);
}
