namespace HomeWork.Domain.Model;

public abstract class Animal : Entity, IAlive
{
    public abstract int Food { get; }

    public DateOnly DateOfBirth { get; }

    public Animal(DateOnly dateOfBirth)
    {
        DateOfBirth = dateOfBirth;
    }
}