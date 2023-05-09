using System.ComponentModel.DataAnnotations.Schema;

namespace RentalService.Domain;

/// <summary>
///     class VehicleModel contains all the information about the car model
/// </summary>
[Table("vehicle_model")]
public class VehicleModel
{
    /// <summary>
    ///     Id - unique Model identifier
    /// </summary>
    [Column("id")]
    public ulong Id { get; set; }

    /// <summary>
    ///     Model - car model
    /// </summary>
    [Column("model")]
    public string Model { get; set; } = string.Empty;

    /// <summary>
    ///     Brand - car brand
    /// </summary>
    [Column("brand")]
    public string Brand { get; set; } = string.Empty;

    /// <summary>
    ///     Vehicles - all cars with this model
    /// </summary>
    public List<Vehicle> Vehicles { get; set; } = new();
}