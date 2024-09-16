using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;


namespace Person.Registry.Core.DI
{
    public static class ApplicationResolver
    {
        public static IServiceCollection AddApplications(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
                services.AddValidatorsFromAssembly(assembly);
            }

            return services;
        }
    }
}
