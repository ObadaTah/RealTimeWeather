using Real_time_weather.InputParser;

namespace Real_time_weather.Factories;

public static class ParserFactory
{
    public static IParsingStrategy Create(string userInput)
    {
        IParsingStrategy parser = userInput.Contains('{') ? 
            new JsonParser() : 
            (userInput.Contains('<') ? new XMLParser() : 
            throw new ArgumentException("Can't Determine Parser Type"));
        return parser;
    }
}
