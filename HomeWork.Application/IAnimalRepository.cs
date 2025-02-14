using HomeWork.Domain;
using HomeWork.Domain.Model;

namespace HomeWork.Application;

public interface IAnimalRepository 
{
    Result<Animal> Create(Animal animal);
    Result<IEnumerable<Animal>> GetAllAnimals();
    Result<IEnumerable<Herbivore>> GetAllHerbivore();
}