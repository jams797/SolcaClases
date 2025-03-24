using ApiSolcaClase.Bll.Security;
using ApiSolcaClase.Bll.WeatherForecast;
using ApiSolcaClase.Filters;
using ApiSolcaClase.Models.DB;
using ApiSolcaClase.Repository.MUsers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Filters
builder.Services.AddScoped<SessionFilter>();

// Conexion DB
builder.Services.AddDbContext<ModelContext>((options) => options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Interfaces - Bll
builder.Services.AddScoped<IWeatherForecastBll, WeatherForecastBll>();
builder.Services.AddScoped<ISecurityBll, SecurityBll>();
// Interfaces - Rep
builder.Services.AddScoped<IUserRepository, UserRepository>();

//builder.Services.AddControllers(options => {
//        options.Filters.Add<SessionFilter>();
//    }
//);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
