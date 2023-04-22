using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleRentals.Domain;
public class BicycleRental
{
    /// <summary>
    /// RentalId - shows the rental's id
    /// </summary> 
    [Key]
    public int RentalId { get; set; }
    /// <summary>
    /// SerialNumber - shows the Bicycle's id
    /// </summary>  
    [ForeignKey("Bicycle")]
    public int SerialNumber { get; set; }
    public Bicycle Bicycle { get; set; } = null!;
    /// <summary>
    /// CustomerId - shows the customer's id
    /// </summary> 
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    /// <summary>
    /// RentalStartTime - shows the rental Start time
    /// </summary> 
    public DateTime RentalStartTime { get; set; }
    /// <summary>
    /// RentalEndTime - shows the rental end time
    /// </summary> 
    public DateTime RentalEndTime { get; set; }
    public double RentalDurationHours
    {
        get { return (RentalEndTime - RentalStartTime).TotalHours; }
    }
}
