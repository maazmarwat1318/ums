using UMS.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging((o) => { });
builder.Services.AddControllers();
builder.Services.AddSingleton<InMemoryUserService>();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseHttpLogging();
app.UseRouting();
app.MapControllers();
app.MapOpenApi();
app.MapGet("/", () => "User Management System - API running (In-Memory)");

app.Run();

