namespace NexusNova.Api.Options;

public sealed class NovaApiKeyOptions
{
    public const string SectionName = "Security:ApiKey";

    public string HeaderName { get; set; } = "X-Api-Key";

    public string Value { get; set; } = string.Empty;
}
