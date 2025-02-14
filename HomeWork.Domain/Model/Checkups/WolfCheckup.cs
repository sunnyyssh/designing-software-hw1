using HomeWork.Domain.Model.Animals;

namespace HomeWork.Domain.Model.ChedckUps;

public class WolfCheckUp : ICheckUp<Wolf>
{
    private readonly ITimeProvider _time;

    public WolfCheckUp(ITimeProvider time) =>_time = time;

    public HealthinessInfo CheckUp(Wolf animal)
    {
        if (animal.DateOfBirth.AddYears(15) < DateOnly.FromDateTime(_time.Now()))
        {
            return new HealthinessInfo { IsHealthy = false };
        }
        
        return new HealthinessInfo { IsHealthy = true };
    }
}