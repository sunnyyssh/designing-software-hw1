namespace HomeWork.Domain.Model;

public interface ICheckUp<TAnimal> where TAnimal : Animal
{
    public HealthinessInfo CheckUp(TAnimal animal);
}