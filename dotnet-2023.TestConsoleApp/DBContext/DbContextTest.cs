using dotnet_2023.DataBase.DBContext;
using Microsoft.EntityFrameworkCore;

namespace dotnet_2023.TestConsoleApp.DBContext;
public class DbContextTest : DataBaseContext
{
    public DbContextTest() : base() { }

    public DbContextTest(DbContextOptions<DataBaseContext> options)
        : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=Net2023; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;";
        optionsBuilder.UseSqlServer(connectionString);
    }

}
