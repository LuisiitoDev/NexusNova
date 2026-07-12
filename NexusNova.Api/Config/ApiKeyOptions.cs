namespace NexusNova.Api.Config;

/// <summary>
/// Options for the API key used to authenticate incoming requests.
/// </summary>
public sealed class ApiKeyOptions
{
    /// <summary>Configuration section name.</summary>
    public const string SectionName = "Security:ApiKey";

    /// <summary>Name of the HTTP header that carries the API key.</summary>
    public string HeaderName { get; set; } = "X-Api-Key";

    /// <summary>Expected API key value. Stored in user secrets, never in source control.</summary>
    public string Value { get; set; } = string.Empty;
}
