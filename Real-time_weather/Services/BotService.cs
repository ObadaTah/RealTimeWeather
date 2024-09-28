using Newtonsoft.Json.Linq;
using Real_time_weather.Factories;
using Real_time_weather.Models;
using Real_time_weather.Repositories;

namespace Real_time_weather.Services;

public static class BotService
{

    public static List<Bot> LoadBotsFromConfigurations()
    {
        string configurationsString = FileSystemRepository.ReadFromFile("configuration.json");
        JObject json = JObject.Parse(configurationsString);
        List<Bot> bots = BotFactory.CreateBots(json);
        return bots;
    }
}
