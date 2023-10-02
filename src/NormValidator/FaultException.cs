namespace NormValidator;

public class FaultException<T> : Exception
{
    public FaultException(Fault<T> fault)
        : base(fault.Message)
    {
        InnerFault = fault;
    }

    public Fault<T> InnerFault { get; }
}
