using NexusNova.Application.Interfaces;

namespace NexusNova.Application.Services;

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
