using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NormValidator
{
    public interface IValidationResult
    {
        public bool IsValid { get; }

        public IEnumerable<Fault<string?>> GetFlattenErrors();
    }
}
