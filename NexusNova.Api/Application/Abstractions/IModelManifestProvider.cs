using NexusNova.Api.Domain;

namespace NexusNova.Api.Application.Abstractions;

public interface IModelManifestProvider
{
    Task<ModelManifest> GetManifestAsync(CancellationToken cancellationToken = default);
}
