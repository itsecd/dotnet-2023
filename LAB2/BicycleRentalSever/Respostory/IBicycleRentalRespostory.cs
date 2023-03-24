using BicycleRentals;

namespace BicycleSever.Respostory
{
    public interface IBicycleRentalRespostory
    {
        List<Bicycle> FixBicycles { get; }
        List<Customer> FixCustomers { get; }
        List<BicycleRental> FixRentals { get; }
        List<BicycleType> FixTypes { get; }
    }
}