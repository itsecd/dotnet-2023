using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain;
using Taxi.Server;
using Taxi.Server.Repository;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
IMapper? mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<ITaxiRepository, TaxiRepository>();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString(nameof(Taxi));
builder.Services.AddDbContextFactory<TaxiContext>(optionsBuilder => optionsBuilder.UseMySQL(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();