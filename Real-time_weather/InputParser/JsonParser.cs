using Newtonsoft.Json.Linq;

namespace Real_time_weather.InputParser;

public class JsonParser : IParsingStrategy
{
    public bool TryParse(string data, out Weather? weather)
    {
        weather = null;

        try
        {
            JObject json = JObject.Parse(data);

            String location = (json["Location"] ?? "").ToString();
            Double temperature = Double.Parse((json["Temperature"] ?? 0.0).ToString());
            Double humidity = Double.Parse((json["Humidity"] ?? 0.0).ToString());

            weather = new Weather(location, temperature, humidity);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}