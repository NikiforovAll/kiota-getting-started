var builder = DistributedApplication.CreateBuilder(args);

var appProject = builder.AddProject<Projects.App>("app");

builder.AddProject<Projects.App_Client>("app-client")
    .WithReference(appProject);

builder.Build().Run();
