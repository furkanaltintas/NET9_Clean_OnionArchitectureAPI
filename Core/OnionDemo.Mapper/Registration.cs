using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application.Interfaces.AutoMapper;

namespace OnionDemo.Mapper;

public static class Registration
{
    public static void AddCustomMapper(this IServiceCollection services)
    {
        services.AddSingleton<IMapper, AutoMapper.Mapper>();
    }
}