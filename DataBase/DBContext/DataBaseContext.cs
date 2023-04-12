using Microsoft.EntityFrameworkCore;
using RentalService.Domain;

namespace DataBase.DBContext;

public class DataBaseContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    
    public DbSet<IssuedCar> IssuedCars { get; set; }
    
    public DbSet<RefundInformation> RefundInformations { get; set; }
    public DbSet<RentalInformation> RentalInformations { get; set; }
    
    public DbSet<RentalPoint> RentalPoints { get; set; }
    
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleModel> VehicleModel { get; set; }
}