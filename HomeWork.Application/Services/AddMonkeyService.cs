using HomeWork.Domain;
using HomeWork.Domain.Model;
using HomeWork.Domain.Model.AnimalFactories;
using HomeWork.Domain.Model.Animals;

namespace HomeWork.Application.Services;

public interface IAddMonkeyService
{
    Result<Monkey> AddMonkey(int food, int kindness, DateOnly dateOfBirth);
}

public sealed class AddMonkeyService : IAddMonkeyService
{
    private readonly IAnimalRepository _repository;
    private readonly IMonkeyFactory _factory;
    private readonly IZoo _zoo;

    public AddMonkeyService(IAnimalRepository repository, IMonkeyFactory factory, IZoo zoo)
    {
        _repository = repository;
        _factory = factory;
        _zoo = zoo;
    }

    public Result<Monkey> AddMonkey(int food, int kindness, DateOnly dateOfBirth)
    {
        var Monkey = _factory.Create(food, kindness, dateOfBirth);
        if (!Monkey.IsSuccess)
        {
            return Result<Monkey>.WrapError(Monkey);
        }

        Monkey = _zoo.Include(Monkey.Value);
        if (!Monkey.IsSuccess)
        {
            return Result<Monkey>.WrapError(Monkey);
        }

        var createdMonkey = _repository.Create(Monkey.Value);
        return Result<Monkey>.Map(createdMonkey, created => (Monkey)created);
    }
}