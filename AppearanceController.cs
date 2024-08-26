using AForge.Video.DirectShow;
using System.Diagnostics;
using System.Timers;

namespace AppearanceDetector;

internal class AppearanceController
{
    internal readonly AppearanceEvents _appearanceEvents;
    internal bool _isPaused = false;

    private readonly Stopwatch _stopwatch = new();
    private MotionDetector? _motionDetector;

    private readonly Action _showDebugData;
    private readonly Action<bool> _setMovementDetection;
    private readonly Action<bool> _setScreenIsOn;

    private int _screenTimeoutInSeconds = 180;
    private bool _monitorIsOn = true;

    internal int TimeSinceLastMovement
        => (int)Math.Round(_stopwatch.Elapsed.TotalSeconds);

    internal AppearanceController(
        AppearanceEvents appearanceEvents,
        Action showDebugData,
        Action<bool> setMovementDetection,
        Action<bool> setScreenIsOn)
    {
        _showDebugData = showDebugData;
        _appearanceEvents = appearanceEvents;
        _setMovementDetection = setMovementDetection;
        _setScreenIsOn = setScreenIsOn;
        _stopwatch.Start();

        var timer = new System.Timers.Timer();
        timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        timer.Interval = 1000;
        timer.Enabled = true;
    }

    internal void StartMotionCapture(VideoCaptureDevice currentDevice)
    {
        _appearanceEvents.AddEvent("Start current device");
        _motionDetector = new MotionDetector(currentDevice);
        _motionDetector.MotionDetected += MotionDetector_MotionDetected;
        currentDevice.Start();
    }

    internal void SetScreenTimeout(int timeoutInSeconds)
        => _screenTimeoutInSeconds = timeoutInSeconds;

    internal void SetMovementSensitivity(int value)
        => _motionDetector?.SetSensitivity(value);

    private void OnTimedEvent(object? source, ElapsedEventArgs e)
    {
        if (_isPaused)
            return;

        _showDebugData?.Invoke();

        int secondsToKeepScreenOn = _screenTimeoutInSeconds;

        //keep screen on if there is motion, we want to keep the screen on for a while after the last motion
        if (_motionDetector?.HasMotion ?? false)
        {
            _stopwatch.Reset();
            _stopwatch.Start();
        }

        if (TimeSinceLastMovement > secondsToKeepScreenOn)
        {
            try
            {
                if (_monitorIsOn)
                {
                    _monitorIsOn = false;
                    _appearanceEvents.AddEvent("Turn the monitor off");
                    SetMonitorBrightness(0);
                    _setScreenIsOn?.Invoke(false);
                }
            }
            catch { }
            _stopwatch.Reset();
            _stopwatch.Stop();
            _appearanceEvents.AddEvent("No more motion");
        }
    }
    private void MotionDetector_MotionDetected(bool motionStarted)
    {
        if (_isPaused)
            return;

        if (motionStarted)
        {
            try
            {
                if (!_monitorIsOn)
                {
                    _appearanceEvents.AddEvent("Turn the monitor on");
                    SetMonitorBrightness(100);
                    _monitorIsOn = true;

                    _setScreenIsOn?.Invoke(true);
                }
            }
            catch { }
            _stopwatch.Reset();
            _stopwatch.Start();
            _appearanceEvents.AddEvent("Motion detected");
        }

        _setMovementDetection?.Invoke(motionStarted);
    }

    private static void SetMonitorBrightness(int brightness)
        => MonitorController.SetMonitorBrightness((byte)brightness);

    internal void Pause()
    {
        _isPaused = true;
        _appearanceEvents.AddEvent("Detection is paused");
    }

    internal void Resume()
    {
        _isPaused = false;
        _appearanceEvents.AddEvent("Detection is resumed");
    }
}
