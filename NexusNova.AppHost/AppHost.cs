var builder = DistributedApplication.CreateBuilder(args);

var novaApi = builder.AddProject<Projects.NexusNova_Api>("nexusnova-api");


var publicDevTunnel = builder.AddDevTunnel("devtunnel-public")
    .WithAnonymousAccess()
    .WithReference(novaApi.GetEndpoint("https"));

var mauiApp = builder.AddMauiProject("nexusnova", @"../NexusNova.Mobile/NexusNova.csproj");

mauiApp.AddiOSSimulator()
    .WithOtlpDevTunnel()
    .WithReference(novaApi, publicDevTunnel);

mauiApp.AddAndroidEmulator()
    .WithOtlpDevTunnel()
    .WithReference(novaApi, publicDevTunnel);

builder.Build().Run();
