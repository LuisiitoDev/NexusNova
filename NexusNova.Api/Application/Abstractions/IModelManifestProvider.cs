using NexusNova.Api.Domain;

namespace NexusNova.Api.Application.Abstractions;

/// <summary>
/// Provides access to the model manifest from an underlying source.
/// </summary>
public interface IModelManifestProvider
{
    /// <summary>Returns the full manifest of downloadable models.</summary>
    Task<ModelManifest> GetManifestAsync(CancellationToken cancellationToken = default);
}
