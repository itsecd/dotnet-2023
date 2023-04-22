using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BicycleRentals.Domain;
/// <summary>
/// Bicycle - a class describing the bicycle
/// </summary> 
public class Bicycle
{
    /// <summary>
    /// SerialNumber - shows the Bicycle's id
    /// </summary>  
    [Key]
    public int SerialNumber { get; set; }
    /// <summary>
    /// TypeId - shows the Type's id
    /// </summary>  
    [ForeignKey("BicycleType")]
    public int TypeId { get; set; }
    public BicycleType BicycleType { get; set; } = null!;
    /// <summary>
    /// Model - shows the Bicycle's model
    /// </summary>     
    public string? Model { get; set; }
    /// <summary>
    /// Color - shows the Bicycle's color
    /// </summary> 
    public string? Color { get; set; }
    /// <summary>
    /// Rentals - shows the Rentals 
    /// </summary>
    public List<BicycleRental> Rentals { get; set; } = new List<BicycleRental>();
}
