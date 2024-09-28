using AutoFixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Real_time_weather.Models;
using Real_time_weather.Observer;

namespace Real_time_weather.Test.ModelsTests;

public class WeatherTests
{
    private Weather _sut;
    private int _temperature;
    private int _humadity;
    private string _location;
    public WeatherTests()
    {
        Fixture fixture = new();

        _temperature = fixture.Create<int>();
        _humadity = fixture.Create<int>();
        _location = fixture.Create<string>();

        _sut = new Weather(_location, _temperature, _humadity);
    }

    [Fact]
    public void Consturctor_withThreeParameters_initWithRightOrder()
    {
        using (new AssertionScope())
        {
            _sut.Temperature.Should().Be(_temperature);
            _sut.Humidity.Should().Be(_humadity);
            _sut.Location.Should().Be(_location);
            _sut.ToString().Should().Be($"Location: {_location}, Temperature: {_temperature}, Humidity: {_humadity}");
        }
    }

    [Fact]
    public void Attach_AddHumidityBotToObserverList()
    {
        // Arrange
        Fixture fixture = new();
        IObserver observer = fixture.Create<TemperatureBot>();

        // Act
        _sut.Attach(observer);

        // Assert
        _sut.Observers.Should().Contain(observer);
    }

    [Fact]
    public void Attach_AddMultiHumidityBotsToObserverList()
    {
        // Arrange
        Fixture fixture = new();
        List<TemperatureBot> humidityBots = fixture.CreateMany<TemperatureBot>().ToList();

        // Act
        humidityBots.ForEach(x => _sut.Attach(x));

        // Assert
        using (new AssertionScope())
        {
            _sut.Observers.Count.Should().Be(humidityBots.Count);
            _sut.Observers.Should().Contain(humidityBots);
        }
    }

    [Fact]
    public void Attach_AddTemperatureBotToObserverList()
    {
        // Arrange
        Fixture fixture = new();
        IObserver observer = fixture.Create<TemperatureBot>();

        // Act
        _sut.Attach(observer);

        // Assert
        _sut.Observers.Should().Contain(observer);
    }

    [Fact]
    public void Attach_AddMultiTemperatureBotsToObserverList()
    {
        // Arrange
        Fixture fixture = new();
        List<TemperatureBot> temperatureBots = fixture.CreateMany<TemperatureBot>().ToList();

        // Act
        temperatureBots.ForEach(x => _sut.Attach(x));

        // Assert
        using (new AssertionScope())
        {
            _sut.Observers.Count.Should().Be(temperatureBots.Count);
            _sut.Observers.Should().Contain(temperatureBots);
        }
    }
}