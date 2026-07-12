using NexusNova.Api.Application.Abstractions;
using NexusNova.Api.Config;
using NexusNova.Api.Domain;

namespace NexusNova.Api.Endpoints;

public static class ModelManifestEndpoints
{
    public static IEndpointRouteBuilder MapModelManifestEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/models")
            .AddEndpointFilter<ApiKeyEndpointFilter>()
            .WithTags("Models");

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
