namespace BicycleRentals;
/// <summary>
/// BicycleRental - a class describing the rentals of bicycle
/// </summary> 
public class BicycleRental
{
    //constructer
    public BicycleRental()
    {
        Bicycle = new Bicycle();
        Customer = new Customer();
    }
    /// <summary>
    /// Bicycle - shows the bicycle rented
    /// </summary> 
    public Bicycle Bicycle { get; set; }
    /// <summary>
    /// Customer - shows the customer rented
    /// </summary> 
    public Customer Customer { get; set; }
    /// <summary>
    /// RentalStartTime - shows the rental start time
    /// </summary> 
    public DateTime RentalStartTime { get; set; }
    /// <summary>
    /// RentalEndTime - shows the rental end time
    /// </summary> 
    public DateTime RentalEndTime { get; set; }
    /// <summary>
    /// RentalDurationHours - shows the rental period
    /// </summary> 
    public double RentalDurationHours
    {
        get => (RentalEndTime - RentalStartTime).TotalHours;
    }
}