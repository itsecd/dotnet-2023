using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Polyclinic.Domain;
using Polyclinic.Server;

var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));

var mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);


builder.Services.AddControllers();
builder.Services.AddDbContextFactory<PolyclinicDbContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(Polyclinic));
    optionsBuilder.UseMySQL(connectionString);
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
