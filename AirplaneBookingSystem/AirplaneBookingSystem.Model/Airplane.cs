using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneBookingSystem.Model;
/// <summary>
/// Сlass describing an airplane
/// </summary>
public class Airplane
{
    /// <summary>
    /// Unique Id of Airplane 
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; } = 0;
    /// <summary>
    ///  Model of Airplane 
    /// </summary>
    [Column("model")]
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// A flights   
    /// </summary>
    public List<Flight> Flights { get; set; } = new List<Flight>();
    public Airplane() { }
    public Airplane(int id, string model)
    {
        Id = id;
        Model = model;
    }
}