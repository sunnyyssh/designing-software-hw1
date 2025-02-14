using HomeWork.Application;
using HomeWork.Domain;
using HomeWork.Domain.Model;

namespace HomeWork.Infrastructure;

public class InMemoryAnimalRepository : IAnimalRepository
{
    private readonly Dictionary<Guid, Animal> _animals = [];

    public Result<Animal> Create(Animal animal)
    {
        _animals[animal.Id] = animal;
        return Result<Animal>.Success(animal);
    }

    public Result<IEnumerable<Animal>> GetAllAnimals()
    {
        return Result<IEnumerable<Animal>>.Success(_animals.Values);
    }

    public Result<IEnumerable<Herbivore>> GetAllHerbivore()
    {
        return Result<IEnumerable<Herbivore>>.Success(_animals.Values.OfType<Herbivore>());
    }
}
