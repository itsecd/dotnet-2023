namespace BicycleRentals;
/// <summary>
/// BicycleRental - a class describing the rentals of bicycle
/// </summary> 
public class BicycleRental
{
    /// <summary>
    /// SerialNumber - shows the Bicycle's id
    /// </summary>  
    public int SerialNumber { get; set; }
    /// <summary>
    /// CustomerId - shows the customer's id
    /// </summary> 
    public int CustomerId { get; set; }
    /// <summary>
    /// RentalStartTime - shows the rental Start time
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
