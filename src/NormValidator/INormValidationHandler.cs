namespace NormValidator
{
    public interface INormValidationHandler<T>
    {
        Task<ValidationResult> ValidateAsync(T data, CancellationToken cancellationToken = default);
    }
}
