namespace CarRentingSystem.Web.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public static class WebApplicationBuilderExtensions
    {
        public static void AddServices(this IServiceCollection services, Type service)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(service);

            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service provided!");
            }

            Type[] serviceTypes = serviceAssembly.GetTypes().Where(t => t.Name.EndsWith("Service") && !t.IsInterface).ToArray();

            foreach (var serviceType in serviceTypes)
            {
                Type? serviceInterface = serviceType.GetInterface($"I{serviceType.Name}");

                if (serviceInterface == null)
                {
                    throw new InvalidOperationException("Interface for this service is invalid!");
                }

                services.AddScoped(serviceInterface, serviceType);
            }
        }
    }
}
