namespace NormValidator;

public interface IValidationContext
{
    public FaultType DefaultFaultType { get; set; }
    public string DefaultMessage { get; set; }

    IEnumerable<Fault> Validate();
}