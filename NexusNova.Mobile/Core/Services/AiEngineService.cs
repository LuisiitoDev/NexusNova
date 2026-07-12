using NexusNova.Core.Interfaces;
using NexusNova.Domain.Interfaces;

namespace NexusNova.Core.Services;

public sealed class AiEngineService(IPromptBuilder builder) : IAiEngineService
{
    public Task ExecutePromptAsync(string prompt, CancellationToken cancellationToken)
    {
        var builtPrompt = builder.BuildPrompt(prompt);

        throw new NotImplementedException();
    }
}
