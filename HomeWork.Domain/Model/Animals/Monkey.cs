namespace HomeWork.Domain.Model.Animals;

public class Monkey : Herbivore
{
    public override int Food { get; }

    public override int Kindness { get; }

    public Monkey(int food, int kindness)
    {
        Food = food;
        Kindness = kindness;
    }
}