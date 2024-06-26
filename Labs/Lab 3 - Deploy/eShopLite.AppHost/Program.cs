var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");

var products = builder.AddProject<Projects.Products>("products");

builder.AddProject<Projects.Store>("store")
    .WithExternalHttpEndpoints()
    .WithReference(products)
    .WithReference(redis);
    
builder.Build().Run();
