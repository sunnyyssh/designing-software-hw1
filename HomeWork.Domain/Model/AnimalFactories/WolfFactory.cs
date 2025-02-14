using HomeWork.Domain.Model.Animals;
using HomeWork.Domain.Model.Validators;

namespace HomeWork.Domain.Model.AnimalFactories;

public class WolfFactory : IWolfFactory
{
    private readonly IFoodValidator _foodValidator;
    private readonly IDateOfBirthValidator _dateOfBirthValidator;

    public WolfFactory(IFoodValidator foodValidator, IDateOfBirthValidator dateOfBirthValidator)
    {
        _foodValidator = foodValidator;
        _dateOfBirthValidator = dateOfBirthValidator;
    }

    public Result<Wolf> Create(int food, DateOnly dateOfBirth)
    {
        IEnumerable<ValidationError> errors = [];
        errors = errors.Concat(_foodValidator.Validate(food));
        errors = errors.Concat(_dateOfBirthValidator.Validate(dateOfBirth));
        if (errors.Any())
        {
            return Result<Wolf>.ValidationFailed(errors);
        }

        var Wolf = new Wolf(food, dateOfBirth);
        return Result<Wolf>.Success(Wolf);
    }
}
