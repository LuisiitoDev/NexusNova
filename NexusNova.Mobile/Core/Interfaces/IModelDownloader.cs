namespace NexusNova.Core.Interfaces;

public interface IModelDownloader
{
    Task DownloadAsync(string downloadUrl, string destinationPath, CancellationToken cancellationToken);
}
