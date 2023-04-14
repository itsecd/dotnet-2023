using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core;
using SocialNetwork.Data;
using SocialNetwork.Web.Middlewares;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<SocialNetworkContext>(optionsBuilder
	=> optionsBuilder.UseMySQL(builder.Configuration.GetConnectionString(nameof(SocialNetwork))));

builder.Services.AddScoped<ISocialNetworkRepository, SocialNetworkRepository>();
builder.Services.AddScoped<ISocialNetworkService, SocialNetworkService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<NotFoundExceptionMiddleware>();
app.UseMiddleware<ValidationExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
