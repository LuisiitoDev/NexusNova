using NexusNova.Core.Interfaces;

namespace NexusNova.Infraestructure.Services;

public sealed class ModelFileSystemProvider : IModelFileSystemProvider
{
    public string ModelPath => Path.Combine(FileSystem.Current.CacheDirectory, "model");
}
