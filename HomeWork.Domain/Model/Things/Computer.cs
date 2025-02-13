namespace HomeWork.Domain.Model.Things;

public class Computer : Thing
{
    public override int Number { get; }

    public Computer(int number) => Number = number;
}