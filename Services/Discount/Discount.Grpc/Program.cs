using Discount.Grpc.Data;
using Discount.Grpc.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DiscountDataContext>(options => options.UseSqlite(
   builder.Configuration.GetConnectionString("DataBase")!
));
// Add services to the container.
builder.Services.AddGrpc();
var app = builder.Build();
app.UseMigration();
app.MapGrpcService<DiscountService>();

app.Run();
