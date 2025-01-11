namespace Formulatrix.TraficLights;

public class TrafficLight
{
    public string Direction { get; private set; }
    public ColorState State { get; private set; }
    public TrafficLight(string direct)
    {
        Direction = direct;
        State = ColorState.Red;
    }

    public void SetState(ColorState state)
    {
        State = state;
        Console.WriteLine($"{Direction} is {state}");
    }
}