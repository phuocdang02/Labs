var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.api>("api");

builder.AddProject<Projects.web>("web");

builder.Build().Run();
