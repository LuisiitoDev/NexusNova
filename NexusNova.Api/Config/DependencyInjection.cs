using NexusNova.Api.Application.Abstractions;
using NexusNova.Api.Infraestructure.Manifest;

namespace NexusNova.Api.Config;

/// <summary>
/// Registration helpers for the API's services and options.
/// </summary>
public static class DependencyInjection
{
    /// <summary>Registers the manifest provider, options and related services.</summary>
    public static IServiceCollection AddNexusNovaApi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<ApiKeyOptions>()
            .Bind(configuration.GetSection(ApiKeyOptions.SectionName))
            .ValidateOnStart();

        services.AddOptions<ModelManifestOptions>()
            .Bind(configuration.GetSection(ModelManifestOptions.SectionName));

        // The manifest is static, so a cached singleton provider is enough.
        services.AddSingleton<IModelManifestProvider, JsonFileModelManifestProvider>();

        return services;
    }
}
