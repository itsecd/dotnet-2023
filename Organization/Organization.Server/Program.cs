using Microsoft.EntityFrameworkCore;
using Organization.Domain;
using Organization.Server;
using Organization.Server.Repository;
using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContextFactory<EmployeeDbContext>(optionsBuilder =>
        {
            var connectionString = builder.Configuration.GetConnectionString(nameof(Organization.Domain));
            optionsBuilder.UseMySQL(connectionString!);
        });

        builder.Services.AddSingleton<OrganizationRepository>();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddSwaggerGen(options =>
        {
            var docName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var docPath = Path.Combine(AppContext.BaseDirectory, docName);
            options.IncludeXmlComments(docPath);
        });



        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
