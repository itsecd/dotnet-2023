using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using PonrfDomain;
using PonrfServer.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<PonrfContext>(optionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString(nameof(PonrfDomain));
    optionsBuilder.UseMySQL(connectionString);
});

builder.Services.AddSingleton<IPonrfRepository, PonrfRepository>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
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
