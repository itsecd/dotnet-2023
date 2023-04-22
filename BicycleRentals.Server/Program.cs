using AutoMapper;
using BicycleRentals.Server;
using BicycleRentals.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BicycleRentals.Server.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddDbContextFactory<BicycleRentalContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(BicycleRentals)) ?? "defaut connection string";
    optionsBuilder.UseMySQL(connectionString);
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();