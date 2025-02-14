namespace HomeWork.Domain.Model.Animals;

public class Wolf : Predator
{
    public override int Food { get; }

    internal Wolf(int food, DateOnly dateOfBirth) : base(dateOfBirth) => Food = food;
}