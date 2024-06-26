var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.FailApi>("failapi");

builder.AddProject<Projects.RetryApp>("retryapp").WithReference(api).WithExternalHttpEndpoints();

builder.Build().Run();
