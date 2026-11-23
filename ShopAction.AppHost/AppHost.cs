var builder = DistributedApplication.CreateBuilder(args);

var username = builder.AddParameter("db-user", "admin");
var password = builder.AddParameter("db-password", "0147");
builder.AddPostgres("posgres", username, password).WithHostPort(5432)
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("Poc");

builder.Build().Run();
