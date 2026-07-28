using BookStoreApi.Services;
using BookStoreApi.Settings;
var builder = WebApplication.CreateBuilder(args);
var mongoSettings = builder.Configuration
    .GetSection("MongoDB")
    .Get<MongoDBSettings>();
builder.Services.AddSingleton(mongoSettings!);
builder.Services.AddSingleton<BookService>();
builder.Services.AddControllers();
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
app.Run();