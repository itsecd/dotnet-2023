using DotNet2023.DataBase.DBContext;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.Tests.DataBase;
public class DBContext : DataBaseContext
{
    public DBContext() : base() { }

    public DBContext(DbContextOptions<DataBaseContext> options)
        : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database=Net2023; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;";
        optionsBuilder.UseSqlServer(connectionString);
    }
}
