namespace HomeWork.Domain.Model.Things;

public class Table : Thing
{
    public override int Number { get; }

    public Table(int number) => Number = number;
}