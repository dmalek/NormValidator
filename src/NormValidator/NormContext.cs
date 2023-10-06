namespace NormValidator;

public class NormContext<TValue>
{
    private readonly ValidationContext<TValue> _validationContext;
    private readonly INorm<TValue> _norm;

    public NormContext(INorm<TValue> norm, ValidationContext<TValue> validationContext)
    {
        _validationContext = validationContext;
        _norm = norm;
        FaultType = _validationContext.DefaultFaultType;
    }

    public ValidationContext<TValue> ValidationContext => _validationContext;
    public FaultType? FaultType { get; set; }
    public string? Message { get; set; }
    public INorm<TValue> Norm => _norm;

}
