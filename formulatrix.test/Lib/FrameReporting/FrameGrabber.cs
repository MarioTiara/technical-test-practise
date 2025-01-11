using System.Runtime.InteropServices;
using Formulatrix.FrameReporting.Interfaces;

namespace Formulatrix.FrameReporting;

public class FrameGrabber : IFrameGrabber
{
    private byte[] _buffer;

    public event Action<Frame> OnFrameUpdated;

    public void FrameReceived(IntPtr framePtr, int width, int height)
    {
        if (_buffer == null)
        {
            _buffer = new byte[width * height];
        }

        Marshal.Copy(framePtr, _buffer, 0, width * height);
        var bufferedFrame = new Frame(_buffer);

        // Raise event with new frame
        OnFrameUpdated?.Invoke(bufferedFrame);
    }
}