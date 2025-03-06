using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OnionDemo.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
    }
}
