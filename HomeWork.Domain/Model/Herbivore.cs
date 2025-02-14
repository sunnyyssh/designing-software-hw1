
namespace HomeWork.Domain.Model;

public abstract class Herbivore : Animal 
{
    protected Herbivore(DateOnly dateOfBirth) : base(dateOfBirth) 
    { }

    public abstract int Kindness { get; } 
}