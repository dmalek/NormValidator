namespace NormValidator;

public sealed class ValidationContext<TValue> : IValidationContext
{
    private readonly TValue _value;
    private readonly List<NormContext<TValue>> _normContexts = new();

    public ValidationContext(TValue value)
    {
        _value = value;
    }

    public TValue Value => _value;

    public FaultType? DefaultFaultType { get; set; } = null;
    public string DefaultMessage { get; set; } = string.Empty;

    public NormContext<TValue> AddNorm(INorm<TValue> norm)
    {
        if (norm == null)
        {
            throw new InvalidOperationException("Error creating norm!");
        }

        var normContext = new NormContext<TValue>(norm, this);
        _normContexts.Add(normContext);    
        return normContext;
    }

    public IEnumerable<Fault> Validate()
    {
        List<Fault> result = new();
        foreach (var norm in _normContexts)
        {
            var isValid = norm.Norm.Validate(_value);

            if (!isValid)
            {
                if (norm.Norm is INormErrors)
                {
                    foreach (var error in ((INormErrors)norm.Norm).Errors)
                    {
                        result.Add(new Fault( norm.FaultType ?? DefaultFaultType, error ?? DefaultMessage));
                    }
                }
                else
                {
                    result.Add(new Fault( norm.FaultType ?? DefaultFaultType, norm.Message ?? DefaultMessage));
                }
            }
        }

        return result;
    }
}
