using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentalService.Server;
using RentalService.Server.Repository;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RentalServiceDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("RentalService")!));

builder.Services.AddSingleton<IRentalServiceRepository, RentalServiceRepository>();

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
IMapper? mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();