namespace NexusNova.Domain.Models;

public enum SuggestedActionType
{
    Default,
    Warning,
    Calendar
}

public sealed class SuggestedAction
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Label { get; init; } = string.Empty;
    public SuggestedActionType ActionType { get; init; } = SuggestedActionType.Default;
}
