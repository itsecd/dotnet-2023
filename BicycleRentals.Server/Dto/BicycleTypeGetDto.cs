namespace BicycleRentals.Server.Dto;

public class BicycleTypeGetDto
{
    /// <summary>
    /// TypeId - shows the type's id
    /// </summary> 
    public int TypeId { get; set; }
    /// <summary>
    /// TypeName - the string responsible for the type's name of bicycle
    /// </summary> 
    public string? TypeName { get; set; }
    /// <summary>
    /// RentalPricePerHour - shows the Bicycle's price per hour for each type
    /// </summary> 
    public decimal RentalPricePerHour { get; set; }
}
