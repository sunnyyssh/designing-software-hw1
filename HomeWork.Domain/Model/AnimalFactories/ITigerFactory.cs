using HomeWork.Domain.Model.Animals;

namespace HomeWork.Domain.Model.AnimalFactories;

public interface ITigerFactory
{
    public Result<Tiger> Create(int food, DateOnly dateOfBirth);
}