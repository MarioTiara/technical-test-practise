namespace Formulatrix.FrameReporting;

using System;

public class Frame : IDisposable
{
    private bool _disposed;
    private readonly byte[] _rawBuffer;

    public Frame(byte[] raw)
    {
        _rawBuffer = raw ?? throw new ArgumentNullException(nameof(raw));
    }

    public byte[] GetRawData()
    {
        if (_disposed)
            throw new ObjectDisposedException("Frame", "The underlying buffer has been disposed.");

        return _rawBuffer;
    }

    public void Dispose()
    {
        _disposed = true;
    }
}
