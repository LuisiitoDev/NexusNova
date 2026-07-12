namespace NexusNova.Api.Config;

public sealed class ApiKeyOptions
{
    public const string SectionName = "Security:ApiKey";

    public string HeaderName { get; set; } = "X-Api-Key";

    public string Value { get; set; } = string.Empty;
}
