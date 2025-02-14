namespace HomeWork.Domain.Model.Animals;

public class Rabbit : Herbivore
{
    public override int Food { get; }

    public override int Kindness { get; }

    internal Rabbit(int food, int kindness, DateOnly dateOfBirth) : base(dateOfBirth)
    {
        Food = food;
        Kindness = kindness;
    }
}