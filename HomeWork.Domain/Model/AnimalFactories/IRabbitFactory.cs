using HomeWork.Domain.Model.Animals;

namespace HomeWork.Domain.Model.AnimalFactories;

public interface IRabbitFactory
{
    public Result<Rabbit> Create(int food, int kindness, DateOnly dateOfBirth);
}