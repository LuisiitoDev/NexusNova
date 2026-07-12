namespace NexusNova.Domain.Interfaces;

public interface IAiEngineService
{
    Task ExecutePromptAsync(string prompt, CancellationToken cancellationToken);
}