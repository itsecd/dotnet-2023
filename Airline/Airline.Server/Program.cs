using Airline.Server;
using Airline.Server.Repository;
using AirlineModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
//builder.Services.AddSingleton<IAirlineRepository, AirlineRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContextFactory<AirlineContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(Airline));
    optionsBuilder.UseMySQL(connectionString);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();