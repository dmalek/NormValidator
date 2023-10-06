using System.Text.RegularExpressions;

namespace NormValidator;

public class RegexNorm : INorm<string>
{        
    public RegexNorm Match(string expression)
    {
        _expression = expression;
        return this;
    }
    
    private string _expression = string.Empty;

    public bool Validate(string value)
    {
        var match = System.Text.RegularExpressions.Regex.Match((string)value, _expression, RegexOptions.IgnoreCase);
        return match.Success;
    }
}


public static class RegexExtensions
{
    public static NormContext<string> Regex(this ValidationContext<string> context, string expression)
    {
        return context.AddNorm(new RegexNorm().Match(expression));
    }

    public static NormContext<string> Regex(this NormContext<string> context, string expression)
    {        
        return context.ValidationContext.AddNorm(new RegexNorm().Match(expression));
    }
}