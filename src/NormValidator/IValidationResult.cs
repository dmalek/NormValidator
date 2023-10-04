namespace NormValidator
{
    public interface IValidationResult
    {
        public bool IsValid { get; }

        public IDictionary<string, string[]> ToDictionary();
    }
}
