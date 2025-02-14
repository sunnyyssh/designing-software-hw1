using HomeWork.Domain.Model.Animals;

namespace HomeWork.Domain.Model.ChedckUps;

public class MonkeyCheckUp : ICheckUp<Monkey>
{
    private readonly ITimeProvider _time;

    public MonkeyCheckUp(ITimeProvider time) => _time = time;

    public HealthinessInfo CheckUp(Monkey animal)
    {
        if (animal.DateOfBirth.AddYears(10) < DateOnly.FromDateTime(_time.Now()))
        {
            return new HealthinessInfo { IsHealthy = false };
        }
        
        return new HealthinessInfo { IsHealthy = true };
    }
}