
namespace HomeWork.Domain.Model.Validators;

public sealed class DateOfBirthValidator : IDateOfBirthValidator
{
    private readonly ITimeProvider _time;

    public DateOfBirthValidator(ITimeProvider time)
    {
        _time = time;
    }

    public IEnumerable<ValidationError> Validate(DateOnly dateOfBirth)
    {
        List<ValidationError> errors = [];
        if (dateOfBirth >= DateOnly.FromDateTime(_time.Now()))
        {
            errors.Add(new ValidationError("Date of Birth", "It must be in the past"));
        }
        return errors;
    }
}
