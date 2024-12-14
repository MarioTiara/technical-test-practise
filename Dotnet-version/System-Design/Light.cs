namespace System_Design.Trafficlight;

public class Light
{
    public string Direction {get;}
    public ColorState state{get; private set;}

    public Light (string direction)
    => Direction = direction;

    public void SetState(ColorState state)
    => this.state=state;
}