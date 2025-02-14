using HomeWork.Domain.Model.Animals;

namespace HomeWork.Domain.Model.AnimalFactories;

public interface IWolfFactory
{
    public Result<Wolf> Create(int food, DateOnly dateOfBirth);
}