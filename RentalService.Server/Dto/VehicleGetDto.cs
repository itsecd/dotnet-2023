namespace RentalService.Server.Dto;

public class VehicleGetDto
{
    /// <summary>
    ///     Id - unique client identifier
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    ///     Number - unique car number
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    ///     Model - contains the identifier of the car model
    /// </summary>
    public ulong ModelId { get; set; }

    /// <summary>
    ///     Colour - car colour
    /// </summary>
    public string Colour { get; set; } = string.Empty;
}