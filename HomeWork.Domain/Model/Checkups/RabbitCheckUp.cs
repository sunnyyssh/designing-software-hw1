using HomeWork.Domain.Model.Animals;

namespace HomeWork.Domain.Model.ChedckUps;

public class RabbitCheckUp : ICheckUp<Rabbit>
{
    private readonly ITimeProvider _time;

    public RabbitCheckUp(ITimeProvider time) => _time = time;

    public HealthinessInfo CheckUp(Rabbit animal)
    {
        // If rabbit is old and angry then it is unhealthy.
        if (animal.DateOfBirth.AddYears(5) < DateOnly.FromDateTime(_time.Now())
            && animal.Kindness < 3)
        {
            return new HealthinessInfo { IsHealthy = false };
        }

        return new HealthinessInfo { IsHealthy = true };
    }
}