namespace Formulatrix.TraficLights;

public class PedestrianLight
{
    public string Direction { get; private set; }
    public PedestrianState State{ get; private set; }

    public PedestrianLight(string direct)
    {
        Direction = direct;
        State = PedestrianState.Stop;
    }

    public void SetState(PedestrianState state)
    {
        State = state;
        Console.WriteLine($"Pedestrian {Direction} is {state}");
    }
}