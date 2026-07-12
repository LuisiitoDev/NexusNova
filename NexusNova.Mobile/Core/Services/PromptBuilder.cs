using NexusNova.Core.Interfaces;

namespace NexusNova.Core.Services;

public sealed class PromptBuilder : IPromptBuilder
{
    public string BuildPrompt(string userInput)
    {
        return $"""
            <|user|>
                {userInput}<|end|>
            <|assistant|>

            """;
    }
}
