using System.Collections.Concurrent;
using Formulatrix.FrameReporting.Interfaces;

namespace Formulatrix.FrameReporting;

public class FrameQueueManager : IFrameQueueManager
{
    private readonly ConcurrentQueue<Frame> _queue = new();

    public void Enqueue(Frame frame) => _queue.Enqueue(frame);

    public bool TryDequeue(out Frame frame) => _queue.TryDequeue(out frame);
}
