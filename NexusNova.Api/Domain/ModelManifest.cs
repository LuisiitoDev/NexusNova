namespace NexusNova.Api.Domain;

public sealed record ModelManifest
{
    public required string ModelId { get; init; }

    public required string DownloadUrl { get; init; }

    public string? Sha256 { get; init; }

    public long SizeBytes { get; init; }
}
