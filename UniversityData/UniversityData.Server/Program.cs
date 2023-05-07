using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Server;
using UniversityData.Server.Repository;

var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddSingleton(mapper);
//builder.Services.AddSingleton<IUniversityDataRepository, UniversityDataRepository>();

builder.Services.AddDbContext<UniversityDataDbContext>(options => 
    options.UseMySQL(builder.Configuration.GetConnectionString(nameof(UniversityData))!));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
