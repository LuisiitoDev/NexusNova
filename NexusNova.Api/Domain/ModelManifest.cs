namespace NexusNova.Api.Domain;

/// <summary>
/// Manifest returned to the client so it can download and verify an AI model.
/// </summary>
public sealed record ModelManifest
{
    /// <summary>Stable, unique identifier of the model.</summary>
    public required string ModelId { get; init; }

    /// <summary>Absolute URL the client uses to download the model archive.</summary>
    public required string DownloadUrl { get; init; }

    /// <summary>SHA-256 checksum used to verify the downloaded archive.</summary>
    public string? Sha256 { get; init; }

    /// <summary>Size of the archive in bytes.</summary>
    public long SizeBytes { get; init; }
}
