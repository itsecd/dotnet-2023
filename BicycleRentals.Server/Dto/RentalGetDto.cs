namespace BicycleRentals.Server.Dto;

public class RentalGetDto
{
    /// <summary>
    /// RentalId - shows the rental's id
    /// </summary> 
    public int RentalId { get; set; }
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
}
