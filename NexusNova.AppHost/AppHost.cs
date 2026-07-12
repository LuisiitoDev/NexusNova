var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.NexusNova_Api>("nexusnova-api");

builder.AddProject<Projects.NexusNova>("nexusnova");

builder.Build().Run();
