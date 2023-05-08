using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TransportMgmt.Domain;
using TransportMgmtServer;
using TransportMgmtServer.Repository;

var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<ITransportMgmtRepository, TransportMgmtRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContextFactory<TransportMgmtContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(TransportMgmt));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
