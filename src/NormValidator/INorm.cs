namespace NormValidator;

public interface INorm<TValue>
{
    bool Validate(TValue value);
}

public interface INormErrors
{
    public IEnumerable<string> Errors { get; set; }
}

