namespace HomeWork.Domain.Model.Animals;

public class Monkey : Herbivore
{
    public override int Food { get; }

    public override int Kindness { get; }

    internal Monkey(int food, int kindness, DateOnly dateOfBirth) : base(dateOfBirth)
    {
        Food = food;
        Kindness = kindness;
    }
}