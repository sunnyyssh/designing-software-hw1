
namespace HomeWork.Domain.Model.Validators;

public class KindnessValidator : IKindnessValidator
{
    public IEnumerable<ValidationError> Validate(int kindness)
    {
        List<ValidationError> errors = [];
        if (kindness < 0)
        {
            errors.Add(new ValidationError("kindness", "Kindness cannot be less than 0. Animals are not the devils."));
        }
        if (kindness > 10)
        {
            errors.Add(new ValidationError("kindness", "Kindness cannot be more than 10. Amnimals are not so kind."));
        }
        return errors;
    }
}
