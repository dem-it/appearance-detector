namespace AppearanceDetector;

internal class AppearanceEvents
{
    private readonly List<string> _eventHistory = [];
    private const int _maximumEventMessages = 10;

    /// <summary>
    /// Add events, older events will be removed
    /// </summary>
    /// <param name="title"></param>
    public void AddEvent(string title)
    {
        _eventHistory.Add($"{DateTime.Now:HH:mm:ss} - {title}");

        if (_eventHistory.Count > _maximumEventMessages)
            _eventHistory.RemoveAt(0);
    }

    public List<string> GetEvents()
        => _eventHistory;
}
