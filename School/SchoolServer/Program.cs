using AutoMapper;
using SchoolServer;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using School.Classes;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SchoolDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("School")!);
});

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
