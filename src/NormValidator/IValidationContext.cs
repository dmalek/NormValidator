namespace NormValidator
{
    public interface IValidationContext<TValue>
    {
        public TValue Value { get;}
        public INorm<TValue> Norm { get; set; }
        public string Message { get; set; }
        public FaultType FaultType { get; set; }
        public void Validate(string? withMessage = null);
    }
}
