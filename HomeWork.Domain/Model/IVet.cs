namespace HomeWork.Domain.Model;

public interface IVet
{
    public Result<HealthinessInfo> CheckUp<TAnimal>(TAnimal animal) where TAnimal : Animal;
}