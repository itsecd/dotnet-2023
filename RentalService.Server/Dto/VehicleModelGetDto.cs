namespace RentalService.Server.Dto;

public class VehicleModelGetDto
{
    /// <summary>
    ///     Id - unique Model identifier
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    ///     Model - car model
    /// </summary>
    public string Model { get; set; } = string.Empty;

    /// <summary>
    ///     Brand - car brand
    /// </summary>
    public string Brand { get; set; } = string.Empty;
}