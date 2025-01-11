namespace Formulatrix.FrameReporting;

using System.Timers;
using Formulatrix.FrameReporting.Interfaces;

public class FrameCalculateAndStream
{
    private readonly IFrameProcessor _frameProcessor;
    private readonly IFrameGrabber _frameGrabber;
    private readonly IValueReporter _reporter;
    private readonly IFrameQueueManager _frameQueueManager;
    private readonly Timer _timer;

    public FrameCalculateAndStream(
        IFrameGrabber frameGrabber,
        IFrameProcessor frameProcessor,
        IValueReporter reporter,
        IFrameQueueManager frameQueueManager)
    {
        _frameGrabber = frameGrabber;
        _frameProcessor = frameProcessor;
        _reporter = reporter;
        _frameQueueManager = frameQueueManager;


        _frameGrabber.OnFrameUpdated += HandleFrameUpdated;

        _timer = new Timer(1000 / 30);
        _timer.Elapsed += OnTimerElapsed;
    }

    private void HandleFrameUpdated(Frame frame)
    {
        _frameQueueManager.Enqueue(frame);
    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        if (_frameQueueManager.TryDequeue(out Frame frame))
        {
            using (frame) // "using" will automatically dispose frame even there is eception on ProcessFrame of Report
            {
                int result = _frameProcessor.ProcessFrame(frame);
                _reporter.Report(result);
            }
        }
    }

    public void StartStreaming()
    {
        _timer.Enabled = true;
    }

    public void StopStreaming()
    {
        _timer.Enabled = false;
    }
}

