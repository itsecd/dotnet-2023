namespace BikeRental.classes;
/// <summary>
/// Class BikeType has the info about bike types
/// </summary>
public class BikeType
{
    /// <summary>
    /// Name of a bike type
    /// </summary>
    public string TypeName { get; set; } = string.Empty; 

    /// <summary>
    /// Price per hour of rent
    /// </summary>
    public int RentCost { get; set; }
}
