﻿using System.Text.RegularExpressions;

namespace NormValidator.Norms;

public class Regex : INorm<string>
{        
    public Regex Match(string expression)
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
    public static IValidationContext<string> Regex(this IValidationContext<string> context, string expression)
    {        
        context.Norm = new Norms.Regex().Match(expression);
        context.Validate();
        return context;
    }
}