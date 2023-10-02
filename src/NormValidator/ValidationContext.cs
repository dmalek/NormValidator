namespace NormValidator;

public class ValidationContext<TValue, TFault>: IValidationContext<TValue>, IValidationContextFault<TFault>
{
    private readonly ValidationResult<TFault> _result;
    private readonly TValue _value;

    public ValidationContext(ValidationResult<TFault> result, TValue value)
    {
        _result = result;
        _value = value;
    }

    public TValue Value => _value;

    public INorm<TValue> Norm { get; set; }
    public TFault Fault { get; set; }
    public string Message { get; set; } = string.Empty;

    public void Validate(string? withMessage = null)
    {
        if (Norm is null)
        {
            throw new ArgumentNullException("Norm is not assigned!");
        }

        var isValid = Norm.Validate(_value);

        if (!isValid)
        {
            if (withMessage is null && Norm is INormErrors)
            {
                AddErrorsFromNorm();
            }
            else
            {
                _result.AddError(Fault, withMessage ?? Message);
            }            
        }
    }

    private void AddErrorsFromNorm()
    {
        var errors = ((INormErrors)Norm).Errors;
        if (errors.Count() > 0)
        {
            foreach (var error in errors)
            {
                _result.AddError(Fault, error);
            }
        }
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
