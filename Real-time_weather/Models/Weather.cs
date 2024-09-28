
using Real_time_weather.Observer;

namespace Real_time_weather;

public struct Weather : ISubject
{
    public String Location = String.Empty;
    public Double Temperature;
    public Double Humidity;

    private List<IObserver> _observers = new();

    public Weather(String location, Double temperature, Double humidity)
    {
        Location = location;
        Temperature = temperature;
        Humidity = humidity;
    }


    public Weather() { }

    #region Observer Logic
    public void Attach(IObserver observer)
    {
        this._observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this._observers.Remove(observer);
    }

    public List<String> Notify()
    {
        List<String> messages = [];

        foreach (var observer in _observers)
        {
           messages.Add(observer.Update(this));
        }

        return messages;
    }

    // This For Testing Purposes
    public readonly List<IObserver> Observers => _observers;
    #endregion

    public override string ToString()
    {
        return $"Location: {Location}, Temperature: {Temperature}, Humidity: {Humidity}";
    }

}
