using AForge.Video;
using AForge.Video.DirectShow;

namespace AppearanceDetector;

internal class MotionDetector
{
    private const float _minSensitivity = 0.001f;
    private const float _maxSensitivity = 0.002f;
    private float _sensitivity = 0.002f;
    private int _mvDetectionThreshold = 0;
    private int _mvPrevFrameScore = 0;
    private readonly List<int> _lastFrameScores = [];

    public bool HasMotion = false;

    public delegate void MotionDelegate(bool motionStarted);

    public event MotionDelegate? MotionDetected;

    public MotionDetector(VideoCaptureDevice device)
    {
        device.NewFrame += Device_NewFrame;
    }

    private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
        Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
        bool hasMotion = DetectMotion(frame);
        if (hasMotion != HasMotion)
        {
            HasMotion = hasMotion;
            MotionDetected?.Invoke(HasMotion);
        }
    }

    internal bool DetectMotion(Bitmap frame)
    {
        int mvFrameScore = 0;
        int pixelCheckDensity = 50;
        for (int i = 0; i < frame.Height; i += pixelCheckDensity)
        {
            for (int j = 0; j < frame.Width; j += pixelCheckDensity)
            {
                var color = frame.GetPixel(j, i);
                mvFrameScore += color.R;
                mvFrameScore += color.G;
                mvFrameScore += color.B;
                mvFrameScore += color.A;
            }
        }

        int mvScoreDifference = Math.Abs(_mvPrevFrameScore - mvFrameScore);

        _mvPrevFrameScore = mvFrameScore;
        _mvDetectionThreshold = (int)(_sensitivity * _mvPrevFrameScore);

        _lastFrameScores.Add(mvScoreDifference);
        if (_lastFrameScores.Count > 50)
            _lastFrameScores.RemoveAt(0);

        var averageFramescore = Math.Round(_lastFrameScores.Average());

        bool isMovementDetected = averageFramescore > _mvDetectionThreshold;
        return isMovementDetected;
    }

    /// <summary>
    /// range van 0.001f - 0.002f
    /// 0 = 0.002f
    /// 10 = 0.001f
    /// linear scale
    /// </summary>
    /// <param name="value">value between 0 and 10, where 0 is low sensitivity and 10 is high sensitivity</param>
    internal void SetSensitivity(int value)
    {
        value = 10 - value;
        _sensitivity = _minSensitivity + (value / 10f) * (_maxSensitivity - _minSensitivity);
    }
}
