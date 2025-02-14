namespace HomeWork.Domain.Model.Animals;

public class Tiger : Predator
{
    public override int Food { get; }

    internal Tiger(int food, DateOnly dateOfBirth) : base(dateOfBirth)
    {
        Food = food;
    }
}