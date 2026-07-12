using NexusNova.Api.Config;
using NexusNova.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Register the manifest provider, options and related services.
builder.Services.AddNexusNovaApi(builder.Configuration);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapModelManifestEndpoints();

app.Run();
