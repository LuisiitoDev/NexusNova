using NexusNova.Api.Domain.Models;

namespace NexusNova.Api.Domain.Interfaces;

public interface IModelManifestProvider
{
    Task<ModelManifest> GetManifestAsync(CancellationToken cancellationToken = default);
}
