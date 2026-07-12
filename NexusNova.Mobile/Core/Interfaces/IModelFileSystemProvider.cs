namespace NexusNova.Core.Interfaces;

public interface IModelFileSystemProvider
{
    string GetModelPath();
    Task SaveModel(byte[] model);
}
