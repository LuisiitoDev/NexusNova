using NexusNova.Api.Application.Abstractions;
using NexusNova.Api.Infraestructure.Manifest;

namespace NexusNova.Api.Config;

public static class DependencyInjection
{
    public static IServiceCollection AddNexusNovaApi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<ApiKeyOptions>()
            .Bind(configuration.GetSection(ApiKeyOptions.SectionName))
            .ValidateOnStart();

        services.AddOptions<ModelManifestOptions>()
            .Bind(configuration.GetSection(ModelManifestOptions.SectionName));

        services.AddSingleton<IModelManifestProvider, JsonFileModelManifestProvider>();

        return services;
    }
}
