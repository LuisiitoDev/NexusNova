namespace NexusNova.Api.Options;

public sealed class ModelManifestOptions
{
    public const string SectionName = "ModelManifest";

    public string FilePath { get; set; } = "Config/model-manifest.json";
}
