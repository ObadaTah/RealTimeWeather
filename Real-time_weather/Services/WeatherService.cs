using Real_time_weather.Factories;
using Real_time_weather.InputParser;

namespace Real_time_weather.Services;

public static class WeatherService
{
    public static Weather GetWeatherDataFromUser()
    {
        Weather? weather;

        while (true)
        {
            Console.WriteLine("Enter Weather Info");
            string userInput = Console.ReadLine() ?? "";

            IParsingStrategy parser = ParserFactory.Create(userInput);

            ParsingContext pc = new(parser);

            if (pc.ParseString(userInput, out weather))
                break;
            Console.WriteLine("Error Reading User Input!");
        }
        return (Weather)weather!;
    }
}
