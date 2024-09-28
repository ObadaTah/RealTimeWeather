
using Newtonsoft.Json.Linq;
using Real_time_weather.Models;

namespace Real_time_weather.Factories;

public static class BotFactory
{
    public static List<Bot> CreateBots(JObject json)
    {
        List<Bot> bots = new List<Bot>();
        Dictionary<string, JToken>? dictObj = json.ToObject<Dictionary<string, JToken>>();
        foreach ((string? name, JToken? bot) in dictObj!)
        {
            string message = (bot["message"] ?? "No Message Provided").ToString();
            bool enabled = bool.Parse((bot["enabled"] ?? "fasle").ToString());

            double temperatureThreshold = double.Parse((bot["temperatureThreshold"] ?? double.MaxValue).ToString());
            double humidityThreshold = double.Parse((bot["humidityThreshold"] ?? double.MaxValue).ToString());

            Bot newBot =
                temperatureThreshold < double.MaxValue ?
                MakeTemperatureBot(name, enabled, message, temperatureThreshold) :
                MakeHumidityBot(name, enabled, message, humidityThreshold);

            bots.Add(newBot);
        }
        return bots;
    }

    private static Bot MakeTemperatureBot(String name,
        Boolean isEnabled,
        String Message,
        double threshold) => new TemperatureBot(name, isEnabled, Message, threshold);

    private static Bot MakeHumidityBot(String name,
        Boolean isEnabled,
        String Message,
        double threshold) => new HumidityBot(name, isEnabled, Message, threshold);
}
