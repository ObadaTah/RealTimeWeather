using Real_time_weather.Models;
using Real_time_weather.Services;

namespace Real_time_weather;

internal class Program
{
    static void Main(string[] args)
    {
        List<Bot> bots = BotService.LoadBotsFromConfigurations();

        while (true)
        {
            Weather weather = WeatherService.GetWeatherDataFromUser();

            foreach (var bot in bots)
                weather.Attach(bot);

            weather.Notify().ForEach(x => Console.WriteLine(x));
        }
    }
}