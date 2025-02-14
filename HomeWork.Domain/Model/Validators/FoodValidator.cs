
namespace HomeWork.Domain.Model.Validators;

public class FoodValidator : IFoodValidator
{
    public IEnumerable<ValidationError> Validate(int food)
    {
        List<ValidationError> errors = [];
        if (food <= 0) 
        {
            errors.Add(new ValidationError("food", 
                food == 0 
                    ? "WTF, why 0? Is it even alive?" 
                    : "it must be more than zero"));
        }
        return errors;
    }
}
