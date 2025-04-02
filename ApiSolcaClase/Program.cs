using ApiSolcaClase.Bll.Invoice;
using ApiSolcaClase.Bll.Security;
using ApiSolcaClase.Bll.WeatherForecast;
using ApiSolcaClase.Filters;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Models.DB;
using ApiSolcaClase.Repository.MInvoice;
using ApiSolcaClase.Repository.MInvoiceDetail;
using ApiSolcaClase.Repository.MProduct;
using ApiSolcaClase.Repository.MUsers;
using ApiSolcaClase.WorkerServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpContextAccessor();


// Filters
builder.Services.AddScoped<SessionFilter>();

// Conexion DB
builder.Services.AddDbContext<ModelContext>((options) => options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Interfaces - Bll
builder.Services.AddScoped<IWeatherForecastBll, WeatherForecastBll>();
builder.Services.AddScoped<ISecurityBll, SecurityBll>();
builder.Services.AddScoped<IInvoiceBll, InvoiceBll>();
// Interfaces - Rep
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();

// Worker Service
builder.Services.AddHostedService<KafkaWorkerService>();

// Filter de intercepcion Request
builder.Services.AddControllers(options =>
{
    options.Filters.Add<MidReqFilter>();
}
);


// Filter de Result
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new MidResultFilter());
});
// [TypeFilter(typeof(CustomResponseFilter))]

var app = builder.Build();

var httpContAc = app.Services.GetRequiredService<IHttpContextAccessor>();
HttpContextHelper.Initialize(httpContAc);

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
