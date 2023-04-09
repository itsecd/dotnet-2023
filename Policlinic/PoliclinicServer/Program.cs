using AutoMapper;
using PoliclinicServer;
using PoliclinicServer.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var mapConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<IPoliclinicRepository, PoliclinicRepository>();

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
