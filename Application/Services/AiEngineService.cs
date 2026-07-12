using NexusNova.Application.Interfaces;
using NexusNova.Domain.Interfaces;

namespace NexusNova.Application.Services;

public sealed class AiEngineService(IPromptBuilder builder) : IAiEngineService
{
    public Task ExecutePromptAsync(string prompt, CancellationToken cancellationToken)
    {
        var builtPrompt = builder.BuildPrompt(prompt);

        throw new NotImplementedException();
    }
}
