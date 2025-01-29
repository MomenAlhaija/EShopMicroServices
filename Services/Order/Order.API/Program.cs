using Order.API;
using Order.Application;
using Order.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.
        AddApplicationServices(builder.Configuration)
       .AddInfrastructureServices(builder.Configuration)
       .AddApiServices(builder.Configuration);

app.MapGet("/", () => "Hello World!");

app.Run();
