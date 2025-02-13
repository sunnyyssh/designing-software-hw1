namespace HomeWork.Domain.Model;

public abstract class Thing : Entity, IInventory
{
    public abstract int Number { get; }
}