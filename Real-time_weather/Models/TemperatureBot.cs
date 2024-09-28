using Real_time_weather.Observer;

namespace Real_time_weather.Models;

public class TemperatureBot(string Name,
                 bool IsEnabled,
                 string Message,
                 double TemperatureThreshold) : Bot(Name, IsEnabled, Message)
{
    public override string ToString()
    {
        return $"Name: {Name}, " +
            $"IsEnabled: {IsEnabled}, " +
            $"Message: {Message}, " +
            $"TemperatureThreshold: {TemperatureThreshold}";
    }

    public override String Update(ISubject subject)
    {
        Weather weather = (Weather)subject;
        
        if (TemperatureThreshold <= weather.Temperature && IsEnabled)
            return (Name + ": " + Message);
        return "";
    }
}