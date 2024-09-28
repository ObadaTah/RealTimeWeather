namespace Real_time_weather.InputParser;

public interface IParsingStrategy
{
    public bool TryParse(string data, out Weather? weather);
}