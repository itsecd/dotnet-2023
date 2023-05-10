using System.ComponentModel.DataAnnotations.Schema;

namespace RentalService.Domain;

/// <summary>
///     class Vehicle contains all the information about the existing car
/// </summary>
[Table("vehicle")]
public class Vehicle
{
    /// <summary>
    ///     Id - unique client identifier
    /// </summary>
    [Column("id")]
    public ulong Id { get; set; }

    /// <summary>
    ///     Number - unique car number
    /// </summary>
    [Column("number")]
    public string Number { get; set; } = string.Empty;

    /// <summary>
    ///     Model - contains the identifier of the car model
    /// </summary>
    [Column("vehicle_model_id")]
    public ulong VehicleModelId { get; set; }

    /// <summary>
    ///     VehicleModel - connection with the car model
    /// </summary>
    public VehicleModel VehicleModel { get; set; }

    /// <summary>
    ///     Colour - car colour
    /// </summary>
    [Column("colour")]
    public string Colour { get; set; } = string.Empty;

    /// <summary>
    ///     RentalCases stores all the car rental records
    /// </summary>
    public List<IssuedCar> RentalCases { get; set; } = new();
}