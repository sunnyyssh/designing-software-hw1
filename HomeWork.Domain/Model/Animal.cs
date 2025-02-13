namespace HomeWork.Domain.Model;

public abstract class Animal : Entity, IAlive
{
    public abstract int Food { get; }
}