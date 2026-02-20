using ParcelManagement.Application.Interfaces;
using ParcelManagement.Application.Services;
using ParcelManagement.Infrastructure.Interfaces;
using ParcelManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Register dependencies for DI container

// Application layer
builder.Services.AddScoped<IParcelService, ParcelService>();

// Infrastructure layer
builder.Services.AddSingleton<IParcelRepository, InMemoryParcelRepository>();

// Add Swagger for testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
