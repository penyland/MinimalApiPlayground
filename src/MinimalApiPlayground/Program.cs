using MinimalApiPlayground;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterModules();

var app = builder.Build();
app.MapEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();
