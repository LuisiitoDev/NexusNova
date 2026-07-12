namespace NexusNova.Domain.Models;

public sealed class ChatMessage
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Content { get; init; } = string.Empty;
    public DateTime Timestamp { get; init; } = DateTime.Now;
    public bool IsFromAssistant { get; init; }
    public string FormattedTime => Timestamp.ToString("hh:mm tt");
}
