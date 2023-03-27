namespace RentalService.Domain;

/// <summary>
/// class Vehicle contains all the information about the existing car
/// </summary>
public class Vehicle
{
    /// <summary>
    /// Id - unique client ID
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    /// Number - unique car number
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Model - contains the ID of the car model
    /// </summary>
    public ulong ModelId { get; set; }

    /// <summary>
    /// Colour - car colour
    /// </summary>
    public string Colour { get; set; } = string.Empty;

    /// <summary>
    /// RentalCases stores all the car rental records
    /// </summary>
    public List<IssuedCar> RentalCases { get; set; } = new();
}