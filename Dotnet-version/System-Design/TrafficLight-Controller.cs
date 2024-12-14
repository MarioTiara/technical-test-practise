namespace System_Design;

enum TrafficLightState
{
    Red,
    Yellow,
    Green
}

enum PedestrianSignalState
{
    Walk,
    DontWalk
}

class TrafficLightController
{
    TrafficLightState northLight = TrafficLightState.Red;
    TrafficLightState southLight = TrafficLightState.Red;
    TrafficLightState eastLight = TrafficLightState.Red;
    TrafficLightState westLight = TrafficLightState.Red;

    PedestrianSignalState nsPedestrianSignal = PedestrianSignalState.DontWalk;
    PedestrianSignalState ewPedestrianSignal = PedestrianSignalState.DontWalk;

    int greenTime = 30; // Time for green light
    int yellowTime = 5; // Time for yellow light

    public void StartTrafficLightCycle()
    {
        while (true)
        {
            // Phase 1: North-bound Green
            ActivateNorthBoundGreen();
            WaitFor(greenTime);

            // North Yellow
            ActivateNorthBoundYellow();
            WaitFor(yellowTime);

            // Phase 2: South-bound Green
            ActivateSouthBoundGreen();
            WaitFor(greenTime);

            // South Yellow
            ActivateSouthBoundYellow();
            WaitFor(yellowTime);

            // Phase 3: East-bound Green
            ActivateEastBoundGreen();
            WaitFor(greenTime);

            // East Yellow
            ActivateEastBoundYellow();
            WaitFor(yellowTime);

            // Phase 4: West-bound Green
            ActivateWestBoundGreen();
            WaitFor(greenTime);

            // West Yellow
            ActivateWestBoundYellow();
            WaitFor(yellowTime);
        }
    }

    private void ActivateNorthBoundGreen()
    {
        ResetAllLights();
        northLight = TrafficLightState.Green;
        nsPedestrianSignal = PedestrianSignalState.DontWalk;
        ewPedestrianSignal = PedestrianSignalState.Walk;
        PrintStatus("North-bound Green");
    }

    private void ActivateNorthBoundYellow()
    {
        northLight = TrafficLightState.Yellow;
        PrintStatus("North-bound Yellow");
    }

    private void ActivateSouthBoundGreen()
    {
        ResetAllLights();
        southLight = TrafficLightState.Green;
        nsPedestrianSignal = PedestrianSignalState.DontWalk;
        ewPedestrianSignal = PedestrianSignalState.Walk;
        PrintStatus("South-bound Green");
    }

    private void ActivateSouthBoundYellow()
    {
        southLight = TrafficLightState.Yellow;
        PrintStatus("South-bound Yellow");
    }

    private void ActivateEastBoundGreen()
    {
        ResetAllLights();
        eastLight = TrafficLightState.Green;
        nsPedestrianSignal = PedestrianSignalState.Walk;
        ewPedestrianSignal = PedestrianSignalState.DontWalk;
        PrintStatus("East-bound Green");
    }

    private void ActivateEastBoundYellow()
    {
        eastLight = TrafficLightState.Yellow;
        PrintStatus("East-bound Yellow");
    }

    private void ActivateWestBoundGreen()
    {
        ResetAllLights();
        westLight = TrafficLightState.Green;
        nsPedestrianSignal = PedestrianSignalState.Walk;
        ewPedestrianSignal = PedestrianSignalState.DontWalk;
        PrintStatus("West-bound Green");
    }

    private void ActivateWestBoundYellow()
    {
        westLight = TrafficLightState.Yellow;
        PrintStatus("West-bound Yellow");
    }

    private void ResetAllLights()
    {
        northLight = TrafficLightState.Red;
        southLight = TrafficLightState.Red;
        eastLight = TrafficLightState.Red;
        westLight = TrafficLightState.Red;
        nsPedestrianSignal = PedestrianSignalState.DontWalk;
        ewPedestrianSignal = PedestrianSignalState.DontWalk;
    }

    void WaitFor(int seconds)
    {
        Thread.Sleep(seconds * 1000);
    }

    void PrintStatus(string phase)
    {
        Console.WriteLine($"Phase: {phase}");
        Console.WriteLine($"North Light: {northLight}, South Light: {southLight}");
        Console.WriteLine($"East Light: {eastLight}, West Light: {westLight}");
        Console.WriteLine($"NS Pedestrian Signal: {nsPedestrianSignal}, EW Pedestrian Signal: {ewPedestrianSignal}");
        Console.WriteLine("----------------------------------");
    }
}

