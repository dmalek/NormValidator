namespace NormValidator.Test
{
    internal class AddPlayerValidationHandler : AbstractValidationHandler<Player>
    {
        public override FaultType? DefaultFaultType => CompettitionFaults.InvalidData;

        protected override async Task OnValidate(Player data, CancellationToken cancellationToken = default)
        {
            // competition config
            int maxAgeLimit = 21;
            int minAgeLimit = 17;
            string sport = "footbal";
          
            // validate data annotations
            NormFor(data)
                .DataAnnotations();

            // validate age
            NormFor(data.Age)
                .LessOrEqual(maxAgeLimit)
                    .WithMessage($"The max age limit is {maxAgeLimit}.")
                    .WithFault(CompettitionFaults.AgeLimit)
                .GreaterThen(minAgeLimit)
                    .WithMessage($"The min age limit is {minAgeLimit}.")
                    .WithFault(CompettitionFaults.AgeLimit);

            // check if plyer is registered for competition sport
            NormFor(data.Sports)
                .Contains(sport)
                .WithFault(CompettitionFaults.NotSport)
                .WithMessage($"Player is not registefred for {sport}");

            // Adding custom validations and errors
            // check some external services / database etc...
            var isSuspended = FakeServices.IsPlayerSuspended(data);
            if (isSuspended)
            {
                AddError(CompettitionFaults.PlayerSuspended, $"Player {data.FirstName} is suspended!");
            }

            await Task.CompletedTask;
        }
    }
}
