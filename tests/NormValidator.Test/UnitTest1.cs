namespace NormValidator.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
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


            var result = new ValidationResult<CompettitionFaults>();
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

            var x = result.Errors.Count();
            var y = result.ToDictionary();
            Assert.AreNotEqual(0, x);

        }
    }
}