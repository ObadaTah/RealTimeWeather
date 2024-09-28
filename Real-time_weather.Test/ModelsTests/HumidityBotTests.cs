

using AutoFixture;
using Real_time_weather.Models;

namespace Real_time_weather.Test.ModelsTests;

public class HumidityBotTests
{
    [Fact]
    public void Update_WithWeatherThatSatisfiesThresholdWithHumidityBot_ReturnsNameAndMessage()
    {
        // Arrange
        var fixture = new Fixture();
        var weather = fixture.Create<Weather>();
        var humidityThreshold = weather.Humidity - 1; // - 1 to satisfy threshold
        var bot = new HumidityBot("TestBot", true, "TestMessage", humidityThreshold);

        // Act
        var result = bot.Update(weather);

        // Assert
        Assert.Equal("TestBot: TestMessage", result);
    }

    [Fact]
    public void Update_WithWeatherThatDoesNotSatisfyThresholdWithHumidityBot_ReturnsEmptyString()
    {
        // Arrange
        var fixture = new Fixture();
        var weather = fixture.Create<Weather>();
        var humidityThreshold = weather.Humidity + 1; // + 1 to not satisfy threshold
        var bot = new HumidityBot("TestBot", false, "TestMessage", humidityThreshold);

        // Act
        var result = bot.Update(weather);

        // Assert
        Assert.Equal("", result);
    }

    [Fact]
    public void Update_WithWeatherThatSatisfiesThresholdAndDisabledWithHumidityBot_ReturnsEmptyString()
    {
        // Arrange
        var fixture = new Fixture();
        var weather = fixture.Create<Weather>();
        var humidityThreshold = weather.Humidity - 1; // - 1 to satisfy threshold
        var bot = new HumidityBot("TestBot", false, "TestMessage", humidityThreshold);

        // Act
        var result = bot.Update(weather);

        // Assert
        Assert.Equal("", result);
    }

    [Fact]
    public void Update_WithWeatherThatSatisfiesThresholdWithTemperatureBot_ReturnsNameAndMessage()
    {
        // Arrange
        var fixture = new Fixture();
        var weather = fixture.Create<Weather>();
        var temperatureThreshold = weather.Temperature - 1; // - 1 to satisfy threshold
        var bot = new TemperatureBot("TestBot", true, "TestMessage", temperatureThreshold);

        // Act
        var result = bot.Update(weather);

        // Assert
        Assert.Equal("TestBot: TestMessage", result);
    }

    [Fact]
    public void Update_WithWeatherThatDoesNotSatisfyThresholdWithTemperatureBot_ReturnsEmptyString()
    {
        // Arrange
        var fixture = new Fixture();
        var weather = fixture.Create<Weather>();
        var temperatureThreshold = weather.Temperature + 1; // + 1 to not satisfy threshold
        var bot = new TemperatureBot("TestBot", false, "TestMessage", temperatureThreshold);

        // Act
        var result = bot.Update(weather);

        // Assert
        Assert.Equal("", result);
    }

    [Fact]
    public void Update_WithWeatherThatSatisfiesThresholdAndDisabledWithTemperatureBot_ReturnsEmptyString()
    {
        // Arrange
        var fixture = new Fixture();
        var weather = fixture.Create<Weather>();
        var temperatureThreshold = weather.Temperature - 1; // - 1 to satisfy threshold
        var bot = new TemperatureBot("TestBot", false, "TestMessage", temperatureThreshold);

        // Act
        var result = bot.Update(weather);

        // Assert
        Assert.Equal("", result);
    }
}

