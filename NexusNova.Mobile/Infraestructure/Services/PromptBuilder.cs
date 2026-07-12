using NexusNova.Core.Interfaces;

namespace NexusNova.Infraestructure.Services;

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
