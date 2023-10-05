namespace NormValidator;

public class FaultException : Exception
{
    public FaultException(Fault fault)
        : base(fault.Message)
    {
        InnerFault = fault;
    }

    public Fault InnerFault { get; }
}
