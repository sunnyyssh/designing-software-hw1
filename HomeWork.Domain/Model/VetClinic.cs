using Microsoft.Extensions.DependencyInjection;

namespace HomeWork.Domain.Model;

public class VetClinic : IVet
{
    private readonly IServiceProvider _services;

    public VetClinic(IServiceProvider services)
    {
        _services = services;
    }

    public Result<HealthinessInfo> CheckUp<TAnimal>(TAnimal animal) where TAnimal : Animal
    {
        var checkup = _services.GetRequiredService<ICheckUp<TAnimal>>();
        return Result<HealthinessInfo>.Success(checkup.CheckUp(animal));
    }
}