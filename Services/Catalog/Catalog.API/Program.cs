using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

// Add Services to the Container
builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));

});

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("DataBase")!);
}).UseLightweightSessions().InitializeWith(new CatalogIntialData());

builder.Services.AddValidatorsFromAssembly(assembly);
// Register the custom exception handler
builder.Services.AddExceptionHandler<CustomeExceptionHandler>(); 
// Configure Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddHealthChecks().AddNpgSql();

var app = builder.Build();

// Configure the HTTP Request Pipeline
app.MapCarter();

app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        var exceptionHandler = context.RequestServices.GetRequiredService<CustomeExceptionHandler>();
    });
});
app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.Run();
