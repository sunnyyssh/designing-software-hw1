using HomeWork.Domain.Model.Animals;
using HomeWork.Domain.Model.Validators;

namespace HomeWork.Domain.Model.AnimalFactories;

public class TigerFactory : ITigerFactory
{
    private readonly IFoodValidator _foodValidator;
    private readonly IDateOfBirthValidator _dateOfBirthValidator;

    public TigerFactory(IFoodValidator foodValidator, IDateOfBirthValidator dateOfBirthValidator)
    {
        _foodValidator = foodValidator;
        _dateOfBirthValidator = dateOfBirthValidator;
    }

    public Result<Tiger> Create(int food, DateOnly dateOfBirth)
    {
        IEnumerable<ValidationError> errors = [];
        errors = errors.Concat(_foodValidator.Validate(food));
        errors = errors.Concat(_dateOfBirthValidator.Validate(dateOfBirth));
        if (errors.Any())
        {
            return Result<Tiger>.ValidationFailed(errors);
        }

        var Tiger = new Tiger(food, dateOfBirth);
        return Result<Tiger>.Success(Tiger);
    }
}
