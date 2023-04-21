using Airlines.Server;
using Airlines.Server.Repository;
using AutoMapper;
using System.Reflection;
using Airlines.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContextFactory<AirlinesContext>(optionsBuilder=>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(Airlines));
    optionsBuilder.UseMySQL(connectionString);
});
builder.Services.AddSingleton<IAirlinesRepository, AirlinesRepository>();
builder.Services.AddControllers();
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