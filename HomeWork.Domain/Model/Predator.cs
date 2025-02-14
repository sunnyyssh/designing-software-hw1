namespace HomeWork.Domain.Model;

public abstract class Predator : Animal {
    public Predator(DateOnly dateOfBirth) : base(dateOfBirth)
    { }
}