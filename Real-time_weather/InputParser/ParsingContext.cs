namespace Real_time_weather.InputParser;
public class ParsingContext(IParsingStrategy _parser)
{
    public bool ParseString(string data, out Weather? weather)
    {
        return _parser.TryParse(data, out weather);
    }
}
