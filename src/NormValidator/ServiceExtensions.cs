using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace NormValidator;

public static class ServiceExtensions
{
    public static IServiceCollection AddValidatorProvider(this IServiceCollection services)
    {
        services.AddTransient<IValidatorProvider, ValidatorProvider>();

        var assembly = Assembly.GetCallingAssembly();

        // add validators
        services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(IValidationHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
