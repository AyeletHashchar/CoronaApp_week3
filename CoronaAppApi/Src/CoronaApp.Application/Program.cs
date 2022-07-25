using CoronaApp.Api.Middlewares;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.Functions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;


IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
Log.Logger = new LoggerConfiguration().ReadFrom
    .Configuration(configuration).CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddDbContext<CoronaContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ILocationRepository, LocationFunc>();
builder.Services.AddScoped<IPatientRepository, PatientFunc>();

//configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseValidationErrorHandler();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

public partial class Program { }

