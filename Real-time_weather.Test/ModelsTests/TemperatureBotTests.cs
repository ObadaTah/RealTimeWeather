

using AutoFixture;
using Real_time_weather.Models;

namespace Real_time_weather.Test.ModelsTests;

public class TemperatureBotTests
{
    [Fact]
    public void Update_WithWeatherThatSatisfiesThreshold_ReturnsNameAndMessage()
    {
        // Arrange
        Fixture fixture = new Fixture();
        Weather weather = fixture.Create<Weather>();
        double temperatureThreshold = weather.Temperature - 1; // - 1 to satisfy threshold
        TemperatureBot bot = new TemperatureBot("TestBot", true, "TestMessage", temperatureThreshold);

        // Act
        string result = bot.Update(weather);

        // Assert
        Assert.Equal("TestBot: TestMessage", result);
    }

    [Fact]
    public void Update_WithWeatherThatDoesNotSatisfyThreshold_ReturnsEmptyString()
    {
        // Arrange
        Fixture fixture = new Fixture();
        Weather weather = fixture.Create<Weather>();
        double temperatureThreshold = weather.Temperature + 1; // + 1 to not satisfy threshold
        TemperatureBot bot = new TemperatureBot("TestBot", false, "TestMessage", temperatureThreshold);

        // Act
        string result = bot.Update(weather);

        // Assert
        Assert.Equal("", result);
    }

    [Fact]
    public void Update_WithWeatherThatSatisfiesThresholdAndDisabled_ReturnsEmptyString()
    {
        // Arrange
        Fixture fixture = new Fixture();
        Weather weather = fixture.Create<Weather>();
        double temperatureThreshold = weather.Temperature - 1; // - 1 to satisfy threshold
        TemperatureBot bot = new TemperatureBot("TestBot", false, "TestMessage", temperatureThreshold);

        // Act
        string result = bot.Update(weather);

        // Assert
        Assert.Equal("", result);
    }
}

