using MinimalApiPlayground;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterModules();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapEndpoints();

app.MapGet("/", () => "Hello World!");

app.MapSwagger();
app.UseSwaggerUI();

app.Run();
