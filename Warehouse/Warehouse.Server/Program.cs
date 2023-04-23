using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain;
using Warehouse.Server;
using Warehouse.Server.Repository;

var builder = WebApplication.CreateBuilder(args);
var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddDbContextFactory<WarehouseContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(Warehouse));
    optionsBuilder.UseMySQL(connectionString);
});
builder.Services.AddSingleton<IWarehouseRepository, WarehouseRepository>();
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