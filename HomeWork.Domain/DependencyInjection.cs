using HomeWork.Domain.Model;
using HomeWork.Domain.Model.AnimalFactories;
using HomeWork.Domain.Model.Animals;
using HomeWork.Domain.Model.ChedckUps;
using HomeWork.Domain.Model.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IZoo, Zoo>();
        services.AddScoped<IVet, VetClinic>();

        services.AddSingleton<IKindnessValidator, KindnessValidator>();
        services.AddSingleton<IFoodValidator, FoodValidator>();
        services.AddSingleton<IDateOfBirthValidator, DateOfBirthValidator>();

        services.AddScoped<IMonkeyFactory, MonkeyFactory>();
        services.AddScoped<ITigerFactory, TigerFactory>();
        services.AddScoped<IWolfFactory, WolfFactory>();
        services.AddScoped<IWolfFactory, WolfFactory>();

        services.AddSingleton<ITimeProvider, NowTimeProvider>();

        services.AddSingleton<ICheckUp<Monkey>, MonkeyCheckUp>();
        services.AddSingleton<ICheckUp<Rabbit>, RabbitCheckUp>();
        services.AddSingleton<ICheckUp<Wolf>, WolfCheckUp>();
        services.AddSingleton<ICheckUp<Tiger>, TigerCheckUp>();
        
        return services;
    }
}