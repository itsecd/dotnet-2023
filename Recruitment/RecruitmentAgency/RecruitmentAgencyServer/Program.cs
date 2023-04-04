using RecruitmentAgencyServer.Repository;
using AutoMapper;
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

        var mapperConfig = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
        var mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);

        builder.Services.AddSingleton<IRecruitmentAgencyServerRepository, RecruitmentAgencyServerRepository>();

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
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}
