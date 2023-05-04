using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSharingDomain;
/// <summary>
/// this class describes all cars which can be rented in rental points
/// </summary>
public class Car
{
    /// <summary>
    /// model of the car
    /// </summary>
    [Column("model")]
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// colour of the car
    /// </summary>
    [Column("colour")]
    public string Colour { get; set; } = string.Empty;
    /// <summary>
    /// number of the car
    /// </summary>
    [Column("number")]
    public string Number { get; set; } = string.Empty;
    /// <summary>
    /// id of the car
    /// </summary>
    [Key]
    [Column("id")]
    public uint Id { get; set; }
    /// <summary>
    /// Default constructor
    /// </summary>
    public Car() { }
    /// <summary>
    /// Constructor with parameters
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <param name="colour"></param>
    /// <param name="number"></param>
    public Car(uint id, string model, string colour, string number)
    {
        Id = id;
        Model = model;
        Colour = colour;
        Number = number;
    }
}
