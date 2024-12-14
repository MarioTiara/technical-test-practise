namespace System_Design.OOP;

using System;
using System.Collections.Generic;
using System.Threading;

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

// Traffic light class
class TrafficLight
{
    public string Direction { get; }
    public TrafficLightState State { get; private set; }

    public TrafficLight(string direction)
    {
        Direction = direction;
        State = TrafficLightState.Red;
    }

    public void SetState(TrafficLightState state)
    {
        State = state;
    }

    public void PrintStatus()
    {
        Console.WriteLine($"{Direction} Light: {State}");
    }
}

// Pedestrian signal class
class PedestrianSignal
{
    public PedestrianSignalState State { get; private set; }

    public PedestrianSignal()
    {
        State = PedestrianSignalState.DontWalk;
    }

    public void SetState(PedestrianSignalState state)
    {
        State = state;
    }

    public void PrintStatus(string direction)
    {
        Console.WriteLine($"{direction} Pedestrian Signal: {State}");
    }
}

// Traffic phase class
class TrafficPhase
{
    public string PhaseName { get; }
    public List<TrafficLight> ActiveLights { get; }
    public PedestrianSignal ActivePedestrianSignal { get; }
    public PedestrianSignal InactivePedestrianSignal { get; }

    public TrafficPhase(string phaseName, List<TrafficLight> activeLights,
        PedestrianSignal activePedestrianSignal, PedestrianSignal inactivePedestrianSignal)
    {
        PhaseName = phaseName;
        ActiveLights = activeLights;
        ActivePedestrianSignal = activePedestrianSignal;
        InactivePedestrianSignal = inactivePedestrianSignal;
    }

    public void Activate()
    {
        // Set all active lights to green
        foreach (var light in ActiveLights)
        {
            light.SetState(TrafficLightState.Green);
        }
        // Set pedestrian signals
        ActivePedestrianSignal.SetState(PedestrianSignalState.DontWalk);
        InactivePedestrianSignal.SetState(PedestrianSignalState.Walk);
    }

    public void Deactivate()
    {
        // Set all active lights to yellow before turning red
        foreach (var light in ActiveLights)
        {
            light.SetState(TrafficLightState.Yellow);
        }
    }

    public void CompleteDeactivation()
    {
        foreach (var light in ActiveLights)
        {
            light.SetState(TrafficLightState.Red);
        }
    }

    public void PrintStatus()
    {
        Console.WriteLine($"--- {PhaseName} ---");
        foreach (var light in ActiveLights)
        {
            light.PrintStatus();
        }
        ActivePedestrianSignal.PrintStatus("Active");
        InactivePedestrianSignal.PrintStatus("Inactive");
        Console.WriteLine("-------------------");
    }
}

// Traffic light controller class
class TrafficLightController
{
    private List<TrafficPhase> phases;
    private int currentPhaseIndex;
    private int greenTime = 30; // Time for green light in seconds
    private int yellowTime = 5; // Time for yellow light in seconds

    public TrafficLightController()
    {
        // Initialize traffic lights
        var northLight = new TrafficLight("North");
        var southLight = new TrafficLight("South");
        var eastLight = new TrafficLight("East");
        var westLight = new TrafficLight("West");

        // Initialize pedestrian signals
        var nsPedestrianSignal = new PedestrianSignal();
        var ewPedestrianSignal = new PedestrianSignal();

        // Define phases
        phases = new List<TrafficPhase>
        {
            new TrafficPhase("North-bound Green", new List<TrafficLight> { northLight }, nsPedestrianSignal, ewPedestrianSignal),
            new TrafficPhase("South-bound Green", new List<TrafficLight> { southLight }, nsPedestrianSignal, ewPedestrianSignal),
            new TrafficPhase("East-bound Green", new List<TrafficLight> { eastLight }, ewPedestrianSignal, nsPedestrianSignal),
            new TrafficPhase("West-bound Green", new List<TrafficLight> { westLight }, ewPedestrianSignal, nsPedestrianSignal),
        };

        currentPhaseIndex = 0;
    }

    public void StartTrafficLightCycle()
    {
        while (true)
        {
            var currentPhase = phases[currentPhaseIndex];

            // Activate current phase
            currentPhase.Activate();
            currentPhase.PrintStatus();
            WaitFor(greenTime);

            // Deactivate current phase (yellow light)
            currentPhase.Deactivate();
            currentPhase.PrintStatus();
            WaitFor(yellowTime);

            // Complete deactivation (turn red)
            currentPhase.CompleteDeactivation();
            currentPhase.PrintStatus();

            // Move to the next phase
            currentPhaseIndex = (currentPhaseIndex + 1) % phases.Count;
        }
    }

    private void WaitFor(int seconds)
    {
        Thread.Sleep(seconds * 1000);
    }
}

