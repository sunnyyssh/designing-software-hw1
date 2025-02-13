namespace HomeWork.Domain.Model.Animals;

public class Wolf : Predator
{
    public override int Food { get; }

    public Wolf(int food) => Food = food;
}