using Real_time_weather.Observer;

namespace Real_time_weather.Models;

public class HumidityBot(string Name,
                 bool IsEnabled,
                 string Message,
                 double HumidityThreshold) : Bot(Name, IsEnabled, Message)
{
    public override string ToString()
    {
        return $"Name: {Name}, " +
            $"IsEnabled: {IsEnabled}, " +
            $"Message: {Message}, " +
            $"HumidityThreshold: {HumidityThreshold}";
    }

    public override String Update(ISubject subject)
    {
        Weather weather = (Weather)subject;

        if (HumidityThreshold < weather.Humidity && IsEnabled)
            return (Name + ": " + Message);

        return "";
    }
}