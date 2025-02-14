using HomeWork.Domain;
using HomeWork.Domain.Model;
using HomeWork.Domain.Model.AnimalFactories;
using HomeWork.Domain.Model.Animals;

namespace HomeWork.Application.Services;

public interface IAddWolfService
{
    Result<Wolf> AddWolf(int food, DateOnly dateOfBirth);
}

public sealed class AddWolfService : IAddWolfService
{
    private readonly IAnimalRepository _repository;
    private readonly IWolfFactory _factory;
    private readonly IZoo _zoo;

    public AddWolfService(IAnimalRepository repository, IWolfFactory factory, IZoo zoo)
    {
        _repository = repository;
        _factory = factory;
        _zoo = zoo;
    }

    public Result<Wolf> AddWolf(int food, DateOnly dateOfBirth)
    {
        var Wolf = _factory.Create(food, dateOfBirth);
        if (!Wolf.IsSuccess)
        {
            return Result<Wolf>.WrapError(Wolf);
        }

        Wolf = _zoo.Include(Wolf.Value);
        if (!Wolf.IsSuccess)
        {
            return Result<Wolf>.WrapError(Wolf);
        }

        var createdWolf = _repository.Create(Wolf.Value);
        return Result<Wolf>.Map(createdWolf, created => (Wolf)created);
    }
}