using NexusNova.Core.Interfaces;
using NexusNova.Infraestructure.Http;

namespace NexusNova.Infraestructure.Services;

public class InferenceBootstrapService(INovaApiClient nova, IModelDownloader downloader, IModelFileSystemProvider fileSystem)
{
    public async Task EnsureModelAvailableAsync(CancellationToken cancellationToken)
    {
        var manifest = await nova.GetManifestAsync(cancellationToken);

        await downloader.DownloadAsync(manifest.DownloadUrl, fileSystem.GetModelPath(), cancellationToken);
    }
}
