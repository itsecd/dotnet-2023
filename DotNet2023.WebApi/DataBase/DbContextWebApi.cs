using DotNet2023.DataBase.DBContext;
using DotNet2023.WebApi.Service;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.WebApi.DataBase;

public class DbContextWebApi : DataBaseContext
{
    public static readonly ILoggerFactory loggerFactory =
    LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
        builder.SetMinimumLevel(LogLevel.Information);
    });

    public DbContextWebApi() : base() { }

    public DbContextWebApi(DbContextOptions<DataBaseContext> options)
        : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(loggerFactory);
        optionsBuilder.UseSqlServer(Config.ConnectionString);
    }
}
