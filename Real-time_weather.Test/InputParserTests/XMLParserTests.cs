using FluentAssertions;
using FluentAssertions.Execution;
using Real_time_weather.InputParser;


namespace Real_time_weather.Test.InputParserTests;

public class XMLParserTests
{
    [Fact]
    public void Parse_WhenXMLInput_ReturnsTrue()
    {
        // Arrange
        string xmlString = """
            <WeatherData>
                <Location>City Name</Location>
                <Temperature>23.0</Temperature>
                <Humidity>85.0</Humidity>
            </WeatherData>
            """;

        // Act
        XMLParser parser = new();
        parser.TryParse(xmlString, out Weather? weather).Should().BeTrue();
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
    public void Parse_WhenInvalidXML_ReturnsFalse()
    {
        // Arrange
        string xmlString = "invalidinput}{";

        // Act
        XMLParser parser = new();
        parser.TryParse(xmlString, out Weather? weather).Should().BeFalse();

        // Assert
        weather.Should().BeNull();
    }
}
