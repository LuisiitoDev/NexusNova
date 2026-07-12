using NexusNova.Api.Application.Abstractions;
using NexusNova.Api.Config;
using NexusNova.Api.Domain;

namespace NexusNova.Api.Endpoints;

/// <summary>
/// Minimal API endpoints that expose the model manifest to clients.
/// </summary>
public static class ModelManifestEndpoints
{
    /// <summary>Maps the model manifest endpoints, protected by the API key filter.</summary>
    public static IEndpointRouteBuilder MapModelManifestEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/models")
            .AddEndpointFilter<ApiKeyEndpointFilter>()
            .WithTags("Models");

        // Returns the manifest the client uses to download and verify the model.
        group.MapGet("/manifest", async (
                IModelManifestProvider provider,
                CancellationToken cancellationToken) =>
            {
                var manifest = await provider.GetManifestAsync(cancellationToken);
                return Results.Ok(manifest);
            })
            .WithName("GetModelManifest")
            .Produces<ModelManifest>()
            .Produces(StatusCodes.Status401Unauthorized);

        return app;
    }
}
