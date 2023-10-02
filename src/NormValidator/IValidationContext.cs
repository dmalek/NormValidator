namespace NormValidator
{
    public interface IValidationContext<TValue>
    {
        public TValue Value { get;}
        public INorm<TValue> Norm { get; set; }
        public void Validate(string? withMessage = null);
    }

    public interface IValidationContextFault<TFault>
    {
        public TFault Fault { get; set; }
    }
}
