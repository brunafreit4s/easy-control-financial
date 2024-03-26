using EasyControl.Api.Data;
using EasyControl.Api.Domain.Repository.Classes;
using EasyControl.Api.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

CongurationInjectionDependency(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

// 4º - Configuração - Conexão com a base de dados           
static void CongurationInjectionDependency(WebApplicationBuilder builder){    
    string? connectionString = builder.Configuration.GetConnectionString("SqlServerConnectionString");
    builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

    builder.Services
    .AddSingleton(builder.Configuration)
    .AddSingleton(builder.Environment)

    #region Injeção de Dependência
    .AddScoped<IUsuarioRepository, UsuarioRepository>();
    #endregion
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
