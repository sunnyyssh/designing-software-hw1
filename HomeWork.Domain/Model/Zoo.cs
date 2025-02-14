namespace HomeWork.Domain.Model;

public class Zoo : IZoo
{
    private readonly IVet _vet;

    public Zoo(IVet vet)
    {
        _vet = vet;
    }

    public Result<TAnimal> Include<TAnimal>(TAnimal animal) where TAnimal : Animal
    {
        var healthiness = _vet.CheckUp(animal);
        if (!healthiness.IsSuccess)
        {
            return Result<TAnimal>.WrapError(healthiness);
        }
        if (!healthiness.Value.IsHealthy)
        {
            return Result<TAnimal>.ValidationFailed([new ValidationError("", "Unhealthy")]);
        }
        return Result<TAnimal>.Success(animal);
    }
}