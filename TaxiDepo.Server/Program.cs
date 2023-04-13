using System.Reflection;
using AutoMapper;
using TaxiDepo.Server;
using Microsoft.OpenApi.Models;
using TaxiDepo.Server.Repositories;

var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<ITaxiDepoRepository, TaxiDepoRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; 
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Custom TaxiDepo server with basic CRUD-operations",
        Description = "Url: https://localhost:7185/index.html",
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
