
namespace HomeWork.Domain.Model;

public class NowTimeProvider : ITimeProvider
{
    public DateTime Now() => DateTime.Now;
}
