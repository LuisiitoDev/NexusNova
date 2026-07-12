using NexusNova.Domain.Dtos;
using Refit;

namespace NexusNova.Infraestructure.Http;

public interface INovaApiClient
{
    [Get("/")]
    Task<DtoModelManifest> GetManifestAsync(CancellationToken cancellationToken);
}
