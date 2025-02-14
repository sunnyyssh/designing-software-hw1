using HomeWork.Domain;

namespace HomeWork.Application.Services;

public interface ICountAllFoodService 
{
    Result<int> CountAllFood();
}

public sealed class CountAllFoodService : ICountAllFoodService
{
    private readonly IAnimalRepository _repository;

    public CountAllFoodService(IAnimalRepository repository)
    {
        _repository = repository;
    }

    public Result<int> CountAllFood()
    {
        return Result<int>.Map(
            _repository.GetAllAnimals(),
            animals => animals.Sum(x => x.Food));
    }
}
