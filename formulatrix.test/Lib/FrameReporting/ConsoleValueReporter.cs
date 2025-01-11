using Formulatrix.FrameReporting.Interfaces;

namespace Formulatrix.FrameReporting;

public class ConsoleValueReporter : IValueReporter
{
    public void Report(double value)
    {
        Console.WriteLine("Value: " + value);
    }
}
