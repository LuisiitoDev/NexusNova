using NexusNova.Core.Interfaces;

namespace NexusNova.Infraestructure.Services;

public class InferenceBootstrapService(IModelDownloader downloader, IModelFileSystemProvider fileSystem)
{
    public async Task EnsureModelAvailableAsync(CancellationToken cancellationToken)
    {
        string[] files =
        [
          "config.json",
          "model_q4f16.onnx",
          "tokenizer.json",
          "tokenizer_config.json"
        ];

        foreach (var file in files)
        {
            if(File.Exists(Path.Combine(fileSystem.ModelPath, file))) continue;
            
            var downloadUrl = $"https://huggingface.co/buckets/LuisiitoDev/Qwen2.5-1.5B-Instruct/resolve/{file}?download=true";
            await downloader.DownloadAsync(downloadUrl, fileSystem.ModelPath, cancellationToken);    
        }

        new InferenceService(fileSystem.ModelPath);
    }
}
