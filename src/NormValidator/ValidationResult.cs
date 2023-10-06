namespace NormValidator;

public class ValidationResult
{
    protected readonly List<Fault> _errors = new List<Fault> ();

    public ValidationResult()
    {
        DisplayName = nameof(ValidationResult);
    }

    public ValidationResult(string displayName)
    {
        DisplayName = displayName;
    }

    public string DisplayName { get; set; } = string.Empty;

    public bool IsValid => _errors.Count == 0;

    public IEnumerable<Fault> Errors => _errors.AsEnumerable();

    public IDictionary<string, string[]> ToDictionary()
    {
        return _errors
            .GroupBy(x => x.FaultType.ToString())            
            .ToDictionary(g => 
                g.Key, 
                g => g.ToList().Select( y => y.Message).ToArray()
                );
    }

    public void AddError(Fault fault)
    {
        _errors.Add(fault);
    }

    public void AddError(FaultType faultType, string message)
    {
        _errors.Add(new Fault(faultType, message));
    }

    public void Clear()
    {
        _errors.Clear();
    }
}
