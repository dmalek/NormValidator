namespace NormValidator;

public class Fault
{
    private readonly FaultType _faultType;
    private readonly string _message = string.Empty;

    public Fault(FaultType faultType)
    {
        _faultType = faultType;
    }

    public Fault(FaultType type, string message)
    {
        _faultType = type;
        _message = message;
    }

    public FaultType FaultType => _faultType;
    public string Message => _message;

    public override string ToString() => _message;
}
