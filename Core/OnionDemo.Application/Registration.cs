using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application.Exceptions;
using System.Reflection;

namespace OnionDemo.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddTransient<ExceptionMiddleware>();

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
    }
}
