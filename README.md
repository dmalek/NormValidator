# NormValidator
Simple validator with rules and strongly typed errors

```
  var competition = new Compettition()
  {
      Name = "Under 21",
      AgeLimit = 21
  };

  var player = new Player()
  {
      FirstName = "Foo",
      Age = 23,
  };


  var result = new ValidationResult<CompettitionFaults>();
  result.Validate(player)
      .WithFault(CompettitionFaults.InvalidData)
      .DataAnnotations();

  result.Validate(player.Age)
      .WithMessage($"The age limit is {competition.AgeLimit}.")
      .WithFault(CompettitionFaults.AgeLimit)
      .LessOrEqual(competition.AgeLimit);     
```                
