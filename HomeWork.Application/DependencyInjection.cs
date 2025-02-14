using HomeWork.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAddMonkeyService, AddMonkeyService>();
        services.AddScoped<IAddRabbitService, AddRabbitService>();
        services.AddScoped<IAddTigerService, AddTigerService>();
        services.AddScoped<IAddWolfService, AddWolfService>();
        services.AddScoped<ICountAllFoodService, CountAllFoodService>();
        services.AddScoped<IGetAllTouchableService, GetAllTouchableService>();

        return services;
    }
}