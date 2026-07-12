using System.Text.Json;
using Microsoft.Extensions.Options;
using NexusNova.Api.Application.Abstractions;
using NexusNova.Api.Config;
using NexusNova.Api.Domain;

namespace NexusNova.Api.Infraestructure.Manifest;

public sealed class JsonFileModelManifestProvider : IModelManifestProvider
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);

    private readonly string _filePath;
    private readonly SemaphoreSlim _gate = new(1, 1);
    private ModelManifest? _cached;

    public JsonFileModelManifestProvider(
        IHostEnvironment environment,
        IOptions<ModelManifestOptions> options)
    {
        _filePath = Path.Combine(environment.ContentRootPath, options.Value.FilePath);
    }

    public async Task<ModelManifest> GetManifestAsync(CancellationToken cancellationToken = default)
    {
        if (_cached is not null)
        {
            return _cached;
        }

        await _gate.WaitAsync(cancellationToken);
        try
        {
            if (_cached is not null)
            {
                return _cached;
            }

            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException(
                    $"The model manifest file was not found at '{_filePath}'.", _filePath);
            }

            await using var stream = File.OpenRead(_filePath);
            var manifest = await JsonSerializer.DeserializeAsync<ModelManifest>(
                stream, SerializerOptions, cancellationToken)
                ?? throw new InvalidOperationException("The model manifest file is empty or invalid.");

            _cached = manifest;
            return manifest;
        }
        finally
        {
            _gate.Release();
        }
    }
}
