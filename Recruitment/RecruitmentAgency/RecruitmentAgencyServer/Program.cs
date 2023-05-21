using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecruitmentAgency;
using RecruitmentAgencyServer.Repository;
using System.Reflection;

namespace RecruitmentAgencyServer;

/// <summary>
/// A class for a web service
/// </summary>
public class Server
{
    /// <summary>
    /// The main body for a web service server
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContextFactory<RecruitmentAgencyContext>(optionsBuilder =>
        {
            var connectionString = builder.Configuration.GetConnectionString(nameof(RecruitmentAgency));
            optionsBuilder.UseMySQL(connectionString);
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
        app.MapControllers();

        app.Run();
    }
}
