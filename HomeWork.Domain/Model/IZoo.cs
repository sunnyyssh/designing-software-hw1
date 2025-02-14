namespace HomeWork.Domain.Model;

public interface IZoo
{
    public Result<TAnimal> Include<TAnimal>(TAnimal animal) where TAnimal : Animal;
}