using HomeWork.Domain;
using HomeWork.Domain.Model;
using HomeWork.Domain.Model.AnimalFactories;
using HomeWork.Domain.Model.Animals;

namespace HomeWork.Application.Services;

public interface IAddTigerService
{
    Result<Tiger> AddTiger(int food, DateOnly dateOfBirth);
}

public sealed class AddTigerService : IAddTigerService
{
    private readonly IAnimalRepository _repository;
    private readonly ITigerFactory _factory;
    private readonly IZoo _zoo;

    public AddTigerService(IAnimalRepository repository, ITigerFactory factory, IZoo zoo)
    {
        _repository = repository;
        _factory = factory;
        _zoo = zoo;
    }

    public Result<Tiger> AddTiger(int food, DateOnly dateOfBirth)
    {
        var Tiger = _factory.Create(food, dateOfBirth);
        if (!Tiger.IsSuccess)
        {
            return Result<Tiger>.WrapError(Tiger);
        }

        Tiger = _zoo.Include(Tiger.Value);
        if (!Tiger.IsSuccess)
        {
            return Result<Tiger>.WrapError(Tiger);
        }

        var createdTiger = _repository.Create(Tiger.Value);
        return Result<Tiger>.Map(createdTiger, created => (Tiger)created);
    }
}