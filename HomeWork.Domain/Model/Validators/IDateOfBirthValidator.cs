namespace HomeWork.Domain.Model.Validators;

public interface IDateOfBirthValidator 
{
    IEnumerable<ValidationError> Validate(DateOnly dateOfBirth);
}