using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public class NormValidatorServiceConfiguration
{
    internal List<Assembly> AssembliesToRegister { get; } = new();

    public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;

    public NormValidatorServiceConfiguration RegisterServicesFromAssembly(Assembly assembly)
    {
        AssembliesToRegister.Add(assembly);

        return this;
    }
}
