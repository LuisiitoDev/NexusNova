using NexusNova.Core.Interfaces;

namespace NexusNova.Infraestructure.Services;

public class ModelDownloader : IModelDownloader
{
    public async Task DownloadAsync(string downloadUrl, string destinationPath, CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        response.EnsureSuccessStatusCode();
        await using var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None);
        await response.Content.CopyToAsync(fileStream, cancellationToken);
    }
}
