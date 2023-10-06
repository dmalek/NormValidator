namespace NormValidator.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var player = new Player()
            {
                FirstName = "Foo",
                Age = 23,
                Sports = new[] {"athletics", "basketball"}
            };

            var result = await (new AddPlayerValidationHandler()).ValidateAsync(player);

            Assert.AreEqual(result.Errors.Count(), 4);
            Assert.AreEqual(result.Errors.Where( x => x.FaultType == CompettitionFaults.AgeLimit).Count(),  1);
            Assert.AreEqual(result.Errors.Where(x => x.FaultType == CompettitionFaults.NotSport).Count(), 1);
        }
    }
}