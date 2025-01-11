namespace Formulatrix.TraficLights;

public class TrafficLightController
{
    private readonly TrafficLight NortSouth;
    private readonly PedestrianLight PdsNortSouth;
    private readonly TrafficLight WestEast;
    private readonly PedestrianLight PdsWestEast;

    //Duration
    private const int GreenDuration = 10;
    private const int YellowDuration = 5;
    private const int RedDuration = 3;

    public TrafficLightController()
    {
        this.NortSouth = new TrafficLight("Nort-South");
        this.WestEast = new TrafficLight("West-East");
        this.PdsNortSouth = new PedestrianLight("Nort-South");
        this.PdsWestEast = new PedestrianLight("West-East");
    }

    public void StartCyle()
    {
        while (true)
        {
            //Step1: NortSouth Green, EastWest Red
            NortSouth.SetState(ColorState.Green);
            WestEast.SetState(ColorState.Red);
            PdsWestEast.SetState(PedestrianState.Walk);
            PdsNortSouth.SetState(PedestrianState.Stop);
            Thread.Sleep(GreenDuration * 1000);

            //Step2: NortSouth Yellow, EastWest Reed
            NortSouth.SetState(ColorState.Yellow);
            WestEast.SetState(ColorState.Red);
            PdsWestEast.SetState(PedestrianState.Walk);
            PdsNortSouth.SetState(PedestrianState.Stop);
            Thread.Sleep(YellowDuration * 1000);

            //Setp3: NortSouth Red, EastWest Green
            NortSouth.SetState(ColorState.Red);
            WestEast.SetState(ColorState.Green);
            PdsWestEast.SetState(PedestrianState.Stop);
            PdsNortSouth.SetState(PedestrianState.Walk);
            Thread.Sleep(GreenDuration * 1000);

            //Step4: NortSouth Red, EastWest Yellow
            NortSouth.SetState(ColorState.Red);
            WestEast.SetState(ColorState.Yellow);
            PdsWestEast.SetState(PedestrianState.Stop);
            PdsNortSouth.SetState(PedestrianState.Walk);
            Thread.Sleep(YellowDuration * 1000);

            //Step5: NortSouth Red, EastWest Red, clear area
            NortSouth.SetState(ColorState.Red);
            WestEast.SetState(ColorState.Red);
             PdsWestEast.SetState(PedestrianState.Stop);
            PdsNortSouth.SetState(PedestrianState.Stop);
            Thread.Sleep(RedDuration * 1000);

        }
    }
}