# NormValidator
Simple validator with rules and strongly typed errors

## Define faults
```
public class CompettitionFaults : FaultType
{
    public static CompettitionFaults InvalidData = new CompettitionFaults(nameof(InvalidData));

    public static CompettitionFaults AgeLimit = new CompettitionFaults(nameof(AgeLimit));
    
    private CompettitionFaults(string name) : base(name)
    {
    }    
}
```

## Validate data
```
  var competition = new Compettition()
  {
      Name = "Under 21",
      MaxAgeLimit = 21,
      MinAgeLimit = 17
  };

  var player = new Player()
  {
      FirstName = "Foo",
      Age = 23,
  };


  var result = new ValidationResult();
  result.Validate(player)
      .WithFault(CompettitionFaults.InvalidData)
      .DataAnnotations();

  var ageVale = result.Validate(player.Age);
  ageVale.WithFault(CompettitionFaults.AgeLimit)
      .WithMessage($"The max age limit is {competition.MaxAgeLimit}.")
      .LessOrEqual(competition.MaxAgeLimit);

  ageVale.WithMessage($"The minage limit is {competition.MinAgeLimit}.")
      .GreaterThen(competition.MinAgeLimit);

  result.Validate(2)
      .WithFault(CompettitionFaults.AgeLimit)
      .WithMessage($"The minage limit is {competition.MinAgeLimit}.")
      .GreaterThen(competition.MinAgeLimit);

  // add custom error (check database, external service ...)
  result.AddError(CompettitionFaults.InvalidData, "This is custom error");  
```                
