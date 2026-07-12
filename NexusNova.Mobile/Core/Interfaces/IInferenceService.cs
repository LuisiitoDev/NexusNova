using System.Runtime.CompilerServices;

namespace NexusNova.Core.Interfaces;

public interface IInferenceService
{
    IAsyncEnumerable<string> GenerateResponseAsync(string prompt, CancellationToken cancellationToken);
}
