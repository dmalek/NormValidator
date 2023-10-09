using NormValidator;
using NormValidator.Registration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceExtensions
{
    public static IServiceCollection AddNormValidatorProvider(this IServiceCollection services, Action<NormValidatorServiceConfiguration> normCfg)
    {
        var serviceConfig = new NormValidatorServiceConfiguration();
        normCfg.Invoke(serviceConfig);
        services.AddNormValidatorProvider(serviceConfig);

        return services;
    }


    public static IServiceCollection AddNormValidatorProvider(this IServiceCollection services, NormValidatorServiceConfiguration normCfg)
    {
        services.AddTransient<IValidatorProvider, ValidatorProvider>();

        services.AddNormValidatorClasses(normCfg.AssembliesToRegister.ToArray());
        return services;
    }


}
