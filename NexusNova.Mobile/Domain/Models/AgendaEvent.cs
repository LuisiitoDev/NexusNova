namespace NexusNova.Domain.Models;

public sealed class AgendaEvent
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Title { get; init; } = string.Empty;
    public DateTime EventDate { get; init; }
    public bool IsSynced { get; init; } = true;

    public string DateLabel => EventDate.Date == DateTime.Today
        ? "Today"
        : EventDate.Date == DateTime.Today.AddDays(1)
            ? "Tomorrow"
            : EventDate.ToString("MMM d");

    public string TimeLabel => EventDate.ToString("hh:mm tt");
}
