using HomeWork.Domain;
using HomeWork.Domain.Model;

namespace HomeWork.Application.Services;

public interface IGetAllTouchableService
{
    Result<IEnumerable<Herbivore>> GetAllTouchable();
}

public class GetAllTouchableService : IGetAllTouchableService
{
    private const int MinKindness = 6; // '> 5' means '>= 6'
    private readonly IAnimalRepository _repository;

    public GetAllTouchableService(IAnimalRepository repository)
    {
        _repository = repository;
    }

    public Result<IEnumerable<Herbivore>> GetAllTouchable()
    {
        return Result<IEnumerable<Herbivore>>.Map(
            _repository.GetAllHerbivore(),
            herbivores => herbivores.Where(x => x.Kindness >= MinKindness));
    }
}
