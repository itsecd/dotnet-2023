namespace BikeRental.Server.Dto;

/// <summary>
/// Class BikeTypeGetDto has the info about bike types
/// </summary>
public class BikeTypeGetDto
{
    /// <summary>
    /// Id of a bike type
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of a bike type
    /// </summary>
    public string TypeName { get; set; } = string.Empty;

    /// <summary>
    /// Price per hour of rent
    /// </summary>
    public int RentCost { get; set; }
}
