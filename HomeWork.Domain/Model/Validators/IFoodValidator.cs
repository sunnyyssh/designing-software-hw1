namespace HomeWork.Domain.Model.Validators;

public interface IFoodValidator
{
    IEnumerable<ValidationError> Validate(int food);
}