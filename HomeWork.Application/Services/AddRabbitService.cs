using HomeWork.Domain;
using HomeWork.Domain.Model;
using HomeWork.Domain.Model.AnimalFactories;
using HomeWork.Domain.Model.Animals;

namespace HomeWork.Application.Services;

public interface IAddRabbitService
{
    Result<Rabbit> AddRabbit(int food, int kindness, DateOnly dateOfBirth);
}

public sealed class AddRabbitService : IAddRabbitService
{
    private readonly IAnimalRepository _repository;
    private readonly IRabbitFactory _factory;
    private readonly IZoo _zoo;

    public AddRabbitService(IAnimalRepository repository, IRabbitFactory factory, IZoo zoo)
    {
        _repository = repository;
        _factory = factory;
        _zoo = zoo;
    }

    public Result<Rabbit> AddRabbit(int food, int kindness, DateOnly dateOfBirth)
    {
        var rabbit = _factory.Create(food, kindness, dateOfBirth);
        if (!rabbit.IsSuccess)
        {
            return Result<Rabbit>.WrapError(rabbit);
        }
        
        rabbit = _zoo.Include(rabbit.Value);
        if (!rabbit.IsSuccess)
        {
            return Result<Rabbit>.WrapError(rabbit);
        }
        
        var createdRabbit = _repository.Create(rabbit.Value);
        return Result<Rabbit>.Map(createdRabbit, created => (Rabbit)created);
    }
}