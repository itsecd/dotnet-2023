using EmployeeDomain;
using Microsoft.EntityFrameworkCore;
using OrganizationServer;
using OrganizationServer.Repository;
using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContextFactory<EmployeeDbContext>(optionsBuilder =>
        {
            var connectionString = builder.Configuration.GetConnectionString(nameof(EmployeeDomain));
            optionsBuilder.UseMySQL(connectionString);
        });

        builder.Services.AddSingleton<OrganizationRepository>();

        builder.Services.AddControllers();
        /*
                builder.Services.AddDbContextFactory<EmployeeInitializerDbContext>(optionsBuilder =>
                {
                    var connectionString = builder.Configuration.GetConnectionString(nameof(EmployeeDomain));
                    optionsBuilder.UseMySQL(connectionString);
                });*/

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
        /*
        using (var scope = app.Services.CreateScope())
        {
            var service = scope.ServiceProvider;
            var context = service.GetService<EmployeeInitializerDbContext>();
        }*/

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
