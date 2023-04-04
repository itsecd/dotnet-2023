namespace BicycleRentals.Server.Dto;

public class BicycleGetDto
{
    /// <summary>
    /// SerialNumber - shows the Bicycle's id
    /// </summary>  
    public int SerialNumber { get; set; }
    /// <summary>
    /// TypeId - shows the Type's id
    /// </summary>  
    public int TypeId { get; set; }
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
    public List<BicycleRentals.BicycleRental> Rentals { get; set; } = new List<BicycleRentals.BicycleRental>();
}
