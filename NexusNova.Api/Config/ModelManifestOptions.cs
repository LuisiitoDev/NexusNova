namespace NexusNova.Api.Config;

/// <summary>
/// Options that control how the model manifest is loaded.
/// </summary>
public sealed class ModelManifestOptions
{
    /// <summary>Configuration section name.</summary>
    public const string SectionName = "ModelManifest";

    /// <summary>Path to the manifest file, relative to the application content root.</summary>
    public string FilePath { get; set; } = "Config/model-manifest.json";
}
