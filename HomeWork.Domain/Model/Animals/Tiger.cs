namespace HomeWork.Domain.Model.Animals;

public class Tiger : Predator
{
    public override int Food { get; }

    public Tiger(int food)
    {
        Food = food;
    }
}