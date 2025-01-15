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
}).UseLightweightSessions();

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddExceptionHandler<CustomeExceptionHandler>(); // Register the custom exception handler

// Configure Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

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

app.Run();
