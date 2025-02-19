using BL;
using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<iGardenConnectDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("iGardenConnectDBConnection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<ISensorService, SensorService>();

builder.Services.AddScoped<IPlantRepositoy, PlantRepository>();
builder.Services.AddScoped<IPlantService, PlantService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IGardenRepository, GardenRepository>();
builder.Services.AddScoped<IGardenService, GardenService >();

builder.Services.AddScoped<IGardenSensorRepository, GardenSensorRepository>();
builder.Services.AddScoped<IGardenSensorService, GardenSensorService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// Allow CORS
app.UseCors(builder => builder
    .WithOrigins("http://localhost:3000") // Add your allowed origins here
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
