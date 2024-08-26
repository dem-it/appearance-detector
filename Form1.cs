using AForge.Video.DirectShow;

namespace AppearanceDetector;

public partial class Form1 : Form
{
    internal bool _applicationIsExiting = false;
    private readonly AppearanceController _appearanceController;
    internal readonly AppearanceEvents _appearanceEvents;
    private readonly TrayIconContextMenu _trayIconContextMenu;

    private VideoCaptureDevice? _currentDevice;
    private FilterInfoCollection? _allDevices;

    public Form1()
    {
        _appearanceEvents = new();
        _appearanceController = new(
            _appearanceEvents,
            InvokeDebugger,
            InvokeMovementDetectionCheckBox,
            InvokeScreenIsOnCheckBox
            );
        InitializeComponent();

        _trayIconContextMenu = new(this);

        trayIcon.ContextMenuStrip = _trayIconContextMenu.Construct();
    }

    internal void Resume()
    {
        if (!_appearanceController._isPaused)
            return;

        StartCurrentDevice();

        _trayIconContextMenu.Resume();
        _appearanceController.Resume();
        buttonPauseContinue.Text = "Pause the detection";
    }

    internal void Pause()
    {
        if (_appearanceController._isPaused)
            return;

        StopCurrentDevice();

        _trayIconContextMenu.Pause();
        _appearanceController.Pause();
        buttonPauseContinue.Text = "Continue the detection";
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        InitializeDevices();
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            Hide();
            e.Cancel = true;
        }
    }

    private void FindDevicesButton_Click(object sender, EventArgs e)
    {
        InitializeDevices();
    }

    private void InitializeDevices()
    {
        _allDevices = WebcamService.DiscoverWebcams();

        devicesComboBox.Items.Clear();

        foreach (FilterInfo device in _allDevices)
            devicesComboBox.Items.Add(device.Name);

        if (_allDevices.Count == 0)
            return;

        devicesComboBox.SelectedIndex = 0;
    }

    private void StartCurrentDevice()
    {
        if (_currentDevice != null)
            _appearanceController.StartMotionCapture(_currentDevice);
    }

    private void InvokeDebugger()
        => TryBeginInvoke(new SetDebugDelegate(SetDebug));

    private void InvokeMovementDetectionCheckBox(bool isMotion)
        => TryBeginInvoke(new SetMovementDetectionCheckBoxDelegate(SetMovementDetectionCheckBoxValue), isMotion);

    private void InvokeScreenIsOnCheckBox(bool screenIsOn)
        => TryBeginInvoke(new SetScreenIsOnCheckBoxDelegate(SetScreenIsOnCheckBoxValue), screenIsOn);

    private void TryBeginInvoke(Delegate method, params object?[]? args)
    {
        if (_applicationIsExiting)
            return;
        BeginInvoke(method, args);
    }

    private void StopCurrentDevice()
        => _currentDevice?.SignalToStop();

    private delegate void SetMovementDetectionCheckBoxDelegate(bool isMotion);
    private void SetMovementDetectionCheckBoxValue(bool isMotion)
        => movementDetectionCheckBox.Checked = isMotion;


    private delegate void SetScreenIsOnCheckBoxDelegate(bool screenIsOn);
    private void SetScreenIsOnCheckBoxValue(bool screenIsOn)
        => screenIsOnCheckbox.Checked = screenIsOn;


    private delegate void SetDebugDelegate();
    private void SetDebug()
    {
        var debugTexts = new List<string>
        {
            $"Time since last movement: {_appearanceController.TimeSinceLastMovement}",
            ""
        };

        var history = _appearanceEvents.GetEvents();
        for (int i = history.Count - 1; i > 0; i--)
            debugTexts.Add(history[i]);

        debugTextBox.Text = string.Join("\r\n", debugTexts);
    }

    private void DevicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_allDevices == null || devicesComboBox.SelectedIndex < 0)
            return;

        StopCurrentDevice();
        _currentDevice = new VideoCaptureDevice(_allDevices[devicesComboBox.SelectedIndex].MonikerString);
        StartCurrentDevice();
    }

    private void TimeoutInSeconds_ValueChanged(object sender, EventArgs e)
        => _appearanceController.SetScreenTimeout((int)timeoutInSeconds.Value);

    private void MovementSensitivity_ValueChanged(object sender, EventArgs e)
        => _appearanceController.SetMovementSensitivity(movementSensitivity.Value);

    private void NotifyIcon_Click(object sender, EventArgs e)
        => Show();

    private void OnApplicationExit(object sender, EventArgs e)
    {
        //Cleanup so that the icon will be removed when the application is closed
        trayIcon.Visible = false;
        StopCurrentDevice();
    }

    private void ButtonPauseContinue_Click(object sender, EventArgs e)
    {
        if (_appearanceController._isPaused)
            Resume();
        else
            Pause();
    }
}
