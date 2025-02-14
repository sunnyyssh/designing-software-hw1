using HomeWork.Domain.Model.Animals;

namespace HomeWork.Domain.Model.AnimalFactories;

public interface IMonkeyFactory
{
    public Result<Monkey> Create(int food, int kindness, DateOnly dateOfBirth);
}