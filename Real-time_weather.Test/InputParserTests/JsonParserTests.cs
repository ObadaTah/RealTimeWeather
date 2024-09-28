using FluentAssertions;
using FluentAssertions.Execution;
using Real_time_weather.InputParser;


namespace Real_time_weather.Test.InputParserTests;

public class JsonParserTests
{
    [Fact]
    public void Parse_WhenJsonInput_ReturnsTrue()
    {
        // Arrange
        string jsonInput = "{'Location': 'City Name', 'Temperature': 23.0, 'Humidity': 85.0}";

        // Act
        JsonParser parser = new();
        parser.TryParse(jsonInput, out Weather? weather).Should().BeTrue();
        Weather weather1 = (Weather)weather!;

        // Assert
        using (new AssertionScope())
        {
            weather1.Should().NotBeNull();
            weather1.Location.Should().Be("City Name");
            weather1.Temperature.Should().Be(23.0);
            weather1.Humidity.Should().Be(85.0);
        }
    }

    [Fact]
    public void Parse_WhenInvalidJson_ReturnsFalse()
    {
        // Arrange
        string jsonInput = "invalidinput}{";

        // Act
        JsonParser parser = new();
        parser.TryParse(jsonInput, out Weather? weather).Should().BeFalse();

        // Assert
        weather.Should().BeNull();
    }
}
