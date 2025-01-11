namespace Formulatrix.FrameReporting.Interfaces;

public interface IFrameGrabber
{
    event Action<Frame> OnFrameUpdated;
}
