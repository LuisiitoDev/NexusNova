using NexusNova.Core.Interfaces;
using System.IO.Compression;

namespace NexusNova.Infraestructure.Services;

public sealed class ModelFileSystemProvider : IModelFileSystemProvider
{
    private static string ModelDirectory => Path.Combine(FileSystem.Current.CacheDirectory, "model");

    public string GetModelPath()
    {
        return ModelDirectory;
    }

    public async Task SaveModel(byte[] model)
    {
        using var ms = new MemoryStream(model);
        using var zip = new ZipArchive(ms, ZipArchiveMode.Read);

        foreach (var entry in zip.Entries)
        {
            var path = Path.Combine(ModelDirectory, entry.FullName);
            using var entryStream = entry.Open();
            using var outStream = File.Create(path);
            await entryStream.CopyToAsync(outStream);
        }
    }
}
