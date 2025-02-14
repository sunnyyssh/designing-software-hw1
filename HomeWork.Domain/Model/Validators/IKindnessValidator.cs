namespace HomeWork.Domain.Model.Validators;

public interface IKindnessValidator
{
    IEnumerable<ValidationError> Validate(int kindness);
}