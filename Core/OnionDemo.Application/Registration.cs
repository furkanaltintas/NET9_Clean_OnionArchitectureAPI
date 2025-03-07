using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application.Beheviors;
using OnionDemo.Application.Exceptions;
using System.Globalization;
using System.Reflection;

namespace OnionDemo.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddTransient<ExceptionMiddleware>();

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr-TR");

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
    }
}
