using HomeWork.Domain.Model.Animals;

namespace HomeWork.Domain.Model.ChedckUps;

public class TigerCheckUp : ICheckUp<Tiger>
{
    private readonly ITimeProvider _time;

    public TigerCheckUp(ITimeProvider time) => _time = time;

    public HealthinessInfo CheckUp(Tiger animal)
    {
        if (animal.DateOfBirth.AddYears(17) < DateOnly.FromDateTime(_time.Now()))
        {
            return new HealthinessInfo { IsHealthy = false };
        }
        
        return new HealthinessInfo { IsHealthy = true };
    }
}