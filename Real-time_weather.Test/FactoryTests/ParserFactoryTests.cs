using FluentAssertions;
using Real_time_weather.Factories;
using Real_time_weather.InputParser;

namespace Real_time_weather.Test.FactoryTests;

public class ParserFactoryTests
{
    [Fact]
    public void Create_WhenJsonInput_ReturnsJsonParser()
    {
        string jsonInput = "{ 'key': 'value' }";
        IParsingStrategy parser = ParserFactory.Create(jsonInput);
        parser.Should().BeOfType<JsonParser>();
    }

    [Fact]
    public void Craete_WhenXmlInput_ReturnsXmlParser()
    {
        string xmlInput = "<key>value</key>";
        IParsingStrategy parser = ParserFactory.Create(xmlInput);
        parser.Should().BeOfType<XMLParser>();
    }

    [Fact]
    public void Create_WhenInvalidInput_ThrowsArgumentException()
    {
        string invalidInput = "key:value";
        Action act = () => ParserFactory.Create(invalidInput);
        act.Should().Throw<ArgumentException>();
    }
}
