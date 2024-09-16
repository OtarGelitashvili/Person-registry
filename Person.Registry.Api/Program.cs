using Microsoft.OpenApi.Models;
using Person.Registry.Api.Middlewares;
using Person.Registry.Core.DI;

var builder = WebApplication.CreateBuilder(args);

new DependencyResolver(builder.Configuration).Resolve(builder.Services);


builder.Services.AddControllers();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Person registy api", Version = "v1" });
});


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler();

app.MapControllers();


app.Run();