using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application.Interfaces.Repositories;
using OnionDemo.Application.Interfaces.UnitOfWorks;
using OnionDemo.Persistence.Context;
using OnionDemo.Persistence.Repositories;
using OnionDemo.Persistence.UnitOfWorks;

namespace OnionDemo.Persistence;

public static class Registration
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt => 
        opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}