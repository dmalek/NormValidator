using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace NormValidator.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IValidatorProvider _validatorProvider;
        private IServiceProvider _serviceProvider;

        private Player _playerToValidate;

        public UnitTest1()
        {
            _playerToValidate = new Player()
            {
                FirstName = "Foo",
                Age = 23,
                Sports = new[] { "athletics", "basketball" }
            };

            IServiceCollection services = new ServiceCollection();
            services.AddValidatorProvider();

            _serviceProvider = services.BuildServiceProvider();

            _validatorProvider = _serviceProvider.GetService<IValidatorProvider>();
        }

        [TestMethod]
        public async Task TestMethod1_DirectValidating()
        {
            var result = await (new AddPlayerValidationHandler()).ValidateAsync(_playerToValidate);

            Assert.AreEqual(result.Errors.Count(), 4);
            Assert.AreEqual(result.Errors.Where( x => x.FaultType == CompettitionFaults.AgeLimit).Count(),  1);
            Assert.AreEqual(result.Errors.Where(x => x.FaultType == CompettitionFaults.NotSport).Count(), 1);
        }

        [TestMethod]
        public async Task TestMethod2_WithValidatorProvider()
        {


            var result = await _validatorProvider.TryToValidateAsync(_playerToValidate);

            Assert.AreEqual(result.Errors.Count(), 4);
            Assert.AreEqual(result.Errors.Where(x => x.FaultType == CompettitionFaults.AgeLimit).Count(), 1);
            Assert.AreEqual(result.Errors.Where(x => x.FaultType == CompettitionFaults.NotSport).Count(), 1);
        }
    }
}