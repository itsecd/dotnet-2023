using Microsoft.EntityFrameworkCore;

namespace Realtor;
public class RealtorDbContext : DbContext
{
    public DbSet<House>? Houses { get; set; }
    public DbSet<Application>? Applications { get; set; }   
    public DbSet<Client>? Clients { get; set; }
    public DbSet<ApplicationHasHouse>? ApplicationHasHouses { get; set; }
    public RealtorDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        

        var firstHouse = new House(1, "Uninhabited", "Prosp. Fatiha Amirkhana, 1b", 594, 100);
        var secondHouse = new House(2, "Residential", "Profsoyuznaya, 22", 48, 3);
        var thirdHouse = new House(3, "Uninhabited", "Cathedral, 7", 12, 1);
        var fourthHouse = new House(4, "Residential", "Volzhsky prospect, 4", 2000, 74);
        var fifthHouse = new House(5, "Uninhabited", "Lesnaya, 23", 45, 2);

        var firstClient = new Client(1, "32218", "336-64-36", "Krasnoarmeyskaya, 1a", "Sergey", "Shnirov");
        var secondClient = new Client(2, "21415", "341-21-09", "Galaktionovskaya, 40", "Ilya", "Paramonov");
        var thirdClient = new Client(3, "59143", "265-89-77", "Communist, 90", "Ivan", "Terrible");
        var fourthClient = new Client(4, "91245", "880-05-55", "Aerodromnaya, 47a", "Michael", "Gorshnev");
        var fifthClient = new Client(5, "57504", "964-98-70", "Lesnaya, 23", "Stiven", "King");

        


        var firstApplication = new Application(1, "Purchase", 2, DateTime.Parse("1973-04-13"), fourthClient.Id);
        var secondApplication = new Application(2, "Sale", 48000000, DateTime.Parse("1111-07-26"),fifthClient.Id);
        var thirdApplication = new Application(3, "Purchase", 48000000, DateTime.Parse("1530-08-25"),firstClient.Id );
        var fourthApplication = new Application(4, "Purchase", 48000000, DateTime.Parse("1530-08-25"),thirdClient.Id );
        var fifthApplication = new Application(5, "Purchase", 2000, DateTime.Parse("1973-08-07"),secondClient.Id );
        var sixthApplication = new Application(6, "Sale", 1, DateTime.Parse("1947-09-21"),fifthClient.Id );
        var seventhApplication = new Application(7, "Purchase", 5, DateTime.Parse("1973-05-13"), fourthClient.Id);

        var firstApplicationHasHouse = new ApplicationHasHouse(1,1,1);
        var secondApplicationHasHouse = new ApplicationHasHouse(2,1,5);
        var thirdApplicationHasHouse = new ApplicationHasHouse(3,2,2);
        var fourthApplicationHasHouse = new ApplicationHasHouse(4,3,3);
        var fifthApplicationHasHouse = new ApplicationHasHouse(5,4,4);
        var sixthApplicationHasHouse = new ApplicationHasHouse(6,5,3);
        var seventhApplicationHasHouse = new ApplicationHasHouse(7,6,5);
        var eighthApplicationHasHouse = new ApplicationHasHouse(8, 7, 1);

        modelBuilder.Entity<Application>()
                    .HasOne(application => application.Clients)
                    .WithMany(client => client.Applications)
                    .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ApplicationHasHouse>()
                    .HasOne(applicationHasHouse => applicationHasHouse.Applications)
                    .WithMany(application => application.ApplicationHasHouses)
                    .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ApplicationHasHouse>()
                    .HasOne(applicationHasHouse => applicationHasHouse.Houses)
                    .WithMany(house => house.ApplicationHasHouses)
                    .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<ApplicationHasHouse>().HasData(new List<ApplicationHasHouse> { firstApplicationHasHouse,secondApplicationHasHouse,thirdApplicationHasHouse,fourthApplicationHasHouse,fifthApplicationHasHouse,sixthApplicationHasHouse,seventhApplicationHasHouse,eighthApplicationHasHouse });
        modelBuilder.Entity<Client>().HasData(new List<Client> { firstClient,secondClient,thirdClient,fourthClient, fifthClient});
        modelBuilder.Entity<House>().HasData(new List<House> { firstHouse, secondHouse, thirdHouse,fourthHouse,fifthHouse });
        modelBuilder.Entity<Application>().HasData(new List<Application> { firstApplication, secondApplication, thirdApplication, fourthApplication, fifthApplication, sixthApplication,seventhApplication });
    }
}
