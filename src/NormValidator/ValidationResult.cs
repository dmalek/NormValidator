namespace NormValidator;

public class ValidationResult<TFault>
{
    protected readonly List<Fault<TFault>> _errors = new List<Fault<TFault>> ();

    public ValidationResult()
    {
        DisplayName = nameof(ValidationResult<TFault>);
    }

    public ValidationResult(string displayName)
    {
        DisplayName = displayName;
    }

    public string DisplayName { get; set; } = string.Empty;

    public bool IsValid => _errors.Count == 0;

    public List<Fault<TFault>> Errors => _errors;

    public void AddError(Fault<TFault> fault)
    {
        _errors.Add(fault);
    }

    public void AddError(TFault fault, string message)
    {
        _errors.Add(new Fault<TFault>(fault, message));
    }
}
