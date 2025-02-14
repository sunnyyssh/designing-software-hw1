using HomeWork.Application;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork.Infrastructure;

public static class DependencyInjection 
{
    public static IServiceCollection AddInfrastucture(this IServiceCollection services) 
    {
        services.AddSingleton<IAnimalRepository, InMemoryAnimalRepository>();

        return services;
    }
}