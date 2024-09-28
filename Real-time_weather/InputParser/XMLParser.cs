using Newtonsoft.Json.Linq;
using System.Xml;

namespace Real_time_weather.InputParser;

public class XMLParser : IParsingStrategy
{
    public bool TryParse(string data, out Weather? weather)
    {
        weather = null;

        try
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(data);

            Weather w = new();

            XmlNode? xn = xml.SelectNodes("WeatherData")?[0];
            
            w.Location = xn?["Location"]?.InnerText ?? "";
            w.Temperature = Double.Parse(xn?["Temperature"]?.InnerText ?? "0.0");
            w.Humidity = Double.Parse(xn?["Humidity"]?.InnerText ?? "0.0");
            
            weather = w;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}