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


            var x = result.Errors.Count();
            Assert.AreNotEqual(0, x);

        }
    }
}