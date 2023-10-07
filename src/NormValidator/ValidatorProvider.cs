using Microsoft.Extensions.DependencyInjection;

namespace NormValidator;

public sealed class ValidatorProvider : IValidatorProvider
{
    private readonly IServiceProvider _serviceProvider;

    public ValidatorProvider(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public async Task<ValidationResult> ValidateAsync<T>(T data, CancellationToken cancellationToken = default)
        where T : class
    {
        var validatorResult = await InternalValidationAsync(data, cancellationToken);

        if (validatorResult is null)
        {
            throw new InvalidOperationException($"No validator registered for data type '{data.GetType().FullName}'.");
        }

        return validatorResult;
    }

    public async Task<ValidationResult> TryToValidateAsync<T>(T data, CancellationToken cancellationToken = default)
        where T : class
    {
        var validatorResult = await InternalValidationAsync(data, cancellationToken);

        // nema registriranog validatora, onda je sve OK (developeru ne treba validator :))
        if (validatorResult is null)
        {
            return new ValidationResult(data.GetType().FullName ?? string.Empty);
        }

        return validatorResult;
    }

    private async Task<ValidationResult?> InternalValidationAsync<T>(T data, CancellationToken cancellationToken = default)
        where T : class
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        // finf validator
        using var scope = _serviceProvider.CreateScope();
        var validatorType = typeof(IValidationHandler<>).MakeGenericType(data.GetType());
        dynamic? validator = scope.ServiceProvider.GetService(validatorType);

        // no validator found
        if (validator is null)
        {
            return null;
        }

        // validate and retun result
        return await (Task<ValidationResult?>)validatorType
            .GetMethod(nameof(IValidationHandler<T>.ValidateAsync))?
            .Invoke(validator, new object[] { data, cancellationToken });
    }

    public IValidationHandler<T>? GetValidator<T>(T data)
        where T : class
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        using var scope = _serviceProvider.CreateScope();
        var validatorType = typeof(IValidationHandler<>).MakeGenericType(data.GetType());
        dynamic? validator = scope.ServiceProvider.GetService(validatorType);
        if (validator == null)
        {
            return null;
        }

        return (IValidationHandler<T>)validator;
    }

    public IValidationHandler<T>? GetRequiredValidator<T>(T data) where T : class
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        IValidationHandler<T>? validator = GetValidator(data);
        if (validator is null)
        {
            throw new InvalidOperationException($"No validator registered for data type '{data.GetType().FullName}'.");
        }

        return validator;
    }
}
