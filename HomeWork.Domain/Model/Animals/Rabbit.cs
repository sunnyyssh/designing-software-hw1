namespace HomeWork.Domain.Model.Animals;

public class Rabbit : Herbivore
{
    public override int Food { get; }

    public override int Kindness { get; }

    public Rabbit(int food, int kindness)
    {
        Food = food;
        Kindness = kindness;
    }
}