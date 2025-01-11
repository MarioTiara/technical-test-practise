namespace Formulatrix.FrameReporting.Interfaces;

public interface IFrameQueueManager
{
    void Enqueue(Frame frame);
    bool TryDequeue(out Frame frame);
}