using Real_time_weather.Observer;

namespace Real_time_weather.Models;

public abstract class Bot(string Name,
                 bool IsEnabled,
                 string Message) : IObserver
{
    public abstract String Update(ISubject subject);
}