using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json.Linq;
using Real_time_weather.Factories;
using Real_time_weather.Models;

namespace Real_time_weather.Test.FactoryTests;

public class BotFactoryTests
{
    private static readonly int[] _thresholds = [70, 30, 0];


    private static readonly bool[] _isEnabled = [true, true, false];

    private static readonly string[] _messages =
    [
        "It looks like it's about to pour down!",
        "Wow, it's a scorcher out there!",
        "Brrr, it's getting chilly!"
    ];

    private static readonly string[] _nameOfBots = ["RainBot", "SunBot", "SnowBot"];


    [Fact]
    public void CreateBots_withAConfigurationsOfThreeBots_ThreeBotsReturnedInAList()
    {
        // Arrange
        JObject _configurationsOfThreeBots = JObject.Parse($$"""
                {
          "{{_nameOfBots[0]}}": {
            "enabled": "{{_isEnabled[0]}}",
            "humidityThreshold": {{_thresholds[0]}},
            "message":"{{_messages[0]}}"
          },
          "{{_nameOfBots[1]}}": {
            "enabled": "{{_isEnabled[1]}}",
            "temperatureThreshold": {{_thresholds[1]}},
            "message": "{{_messages[1]}}"
          },
          "{{_nameOfBots[2]}}": {
            "enabled": "{{_isEnabled[2]}}",
            "temperatureThreshold": {{_thresholds[2]}},
            "message": "{{_messages[2]}}"
          }
        }
        """);

        // Act
        List<Bot> bots = BotFactory.CreateBots(_configurationsOfThreeBots);

        // Assert
        using (new AssertionScope())
        {
            bots.Should().HaveCount(3);

            bots[0].Should().BeOfType<HumidityBot>();
            bots[1].Should().BeOfType<TemperatureBot>();
            bots[2].Should().BeOfType<TemperatureBot>();

            ((HumidityBot)bots[0]).ToString().Should().Be($"Name: {_nameOfBots[0]}, " +
            $"IsEnabled: {_isEnabled[0]}, " +
            $"Message: {_messages[0]}, " +
            $"HumidityThreshold: {_thresholds[0]}");

            ((TemperatureBot)bots[1]).ToString().Should().Be($"Name: {_nameOfBots[1]}, " +
            $"IsEnabled: {_isEnabled[1]}, " +
            $"Message: {_messages[1]}, " +
            $"TemperatureThreshold: {_thresholds[1]}");

            ((TemperatureBot)bots[2]).ToString().Should().Be($"Name: {_nameOfBots[2]}, " +
            $"IsEnabled: {_isEnabled[2]}, " +
            $"Message: {_messages[2]}, " +
            $"TemperatureThreshold: {_thresholds[2]}");
        }
    }
}