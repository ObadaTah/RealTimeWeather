namespace Real_time_weather.Observer;

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    List<String> Notify();

}