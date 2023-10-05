namespace NormValidator;

public class Fault
{
    private readonly FaultType _type;
    private readonly string _message = string.Empty;

    public Fault(FaultType type)
    {
        _type = type;
    }

    public Fault(FaultType type, string message)
    {
        _type = type;
        _message = message;
    }

    public FaultType Type => _type;
    public string Message => _message;

    public override string ToString() => _message;
}
