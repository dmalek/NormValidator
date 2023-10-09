using Microsoft.Extensions.DependencyInjection;
using NormValidator;
using System.Reflection;

namespace NormValidator.Registration;

public static class ServiceRegistrations
{
    public static IServiceCollection AddNormValidatorClasses(this IServiceCollection services, Assembly[] assemblies)
    {
        // add validators
        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IValidationHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
