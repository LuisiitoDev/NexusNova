using NexusNova.Api.Domain.Interfaces;
using NexusNova.Api.Endpoints;
using NexusNova.Api.Infraestructure.Manifest;
using NexusNova.Api.Options;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOptions<NovaApiKeyOptions>()
    .Bind(builder.Configuration.GetSection(NovaApiKeyOptions.SectionName))
    .ValidateOnStart();

builder.Services.AddOptions<ModelManifestOptions>()
    .Bind(builder.Configuration.GetSection(ModelManifestOptions.SectionName));

builder.Services.AddSingleton<IModelManifestProvider, JsonFileModelManifestProvider>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/docs", options =>
    {
        options
            .WithTitle("Nexus Nova")
            .WithTheme(ScalarTheme.Mars)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();

app.MapModelManifestEndpoints();

app.Run();
