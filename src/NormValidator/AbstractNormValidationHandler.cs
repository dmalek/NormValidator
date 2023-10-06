namespace NormValidator;

public abstract class AbstractNormValidationHandler<T> : INormValidationHandler<T>
{
    private readonly ValidationResult _result = new ValidationResult(typeof(T).Name);
    private readonly List<IValidationContext> _contexts = new();


    public abstract FaultType DefaultFaultType { get; }

    public async Task<ValidationResult> ValidateAsync(T data, CancellationToken cancellationToken = default)
    {
        _result.Clear();
        await OnValidate(data, cancellationToken);

        foreach (var item in _contexts)
        {
            var normResult = item.Validate();
            foreach (var fault in normResult)
            {
                _result.AddError(fault);
            }
        }

        return _result;
    }

    protected ValidationContext<TValue> NormFor<TValue>(TValue value)
    {
        var newContext = new ValidationContext<TValue>(value);
        newContext.DefaultFaultType = DefaultFaultType;
        _contexts.Add(newContext);
        return newContext;
    }

    protected void AddError(Fault fault)
    {
        _result.AddError(fault);
    }

    protected void AddError(FaultType faultType, string message)
    {
        _result.AddError(new Fault(faultType, message));
    }

    protected void AddError(string message)
    {
        _result.AddError(new Fault(DefaultFaultType, message));
    }

    protected abstract Task OnValidate(T data, CancellationToken cancellationToken = default);
}
