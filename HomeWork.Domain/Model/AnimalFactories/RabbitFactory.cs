using HomeWork.Domain.Model.Animals;
using HomeWork.Domain.Model.Validators;

namespace HomeWork.Domain.Model.AnimalFactories;

public class RabbitFactory : IRabbitFactory
{
    private readonly IFoodValidator _foodValidator;
    private readonly IKindnessValidator _kindnessValidator;
    private readonly IDateOfBirthValidator _dateOfBirthValidator;

    public RabbitFactory(IFoodValidator foodValidator, IKindnessValidator kindnessValidator, IDateOfBirthValidator dateOfBirthValidator)
    {
        _foodValidator = foodValidator;
        _kindnessValidator = kindnessValidator;
        _dateOfBirthValidator = dateOfBirthValidator;
    }

    public Result<Rabbit> Create(int food, int kindness, DateOnly dateOfBirth)
    {
        IEnumerable<ValidationError> errors = [];
        errors = errors.Concat(_foodValidator.Validate(food));
        errors = errors.Concat(_kindnessValidator.Validate(kindness));
        errors = errors.Concat(_dateOfBirthValidator.Validate(dateOfBirth));
        if (errors.Any())
        {
            return Result<Rabbit>.ValidationFailed(errors);
        }

        var rabbit = new Rabbit(food, kindness, dateOfBirth);
        return Result<Rabbit>.Success(rabbit);
    }
}
