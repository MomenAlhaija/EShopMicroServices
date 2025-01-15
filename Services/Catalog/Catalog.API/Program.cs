var builder = WebApplication.CreateBuilder(args);

//Add Sevices To The Container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("DataBase")!);
}).UseLightweightSessions();


var app = builder.Build();

//Configure the HTTP Request  Pipline
app.MapCarter();

app.Run();
