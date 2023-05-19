using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRental.Domain;
/// <summary>
/// Class BikeType has the info about bike types
/// </summary>
[Table("bike_type")]
public class BikeType
{
    /// <summary>
    /// Id of a bike type
    /// </summary>
    [Column("id")]
    [ForeignKey("type_id")]
    public int Id { get; set; }

    /// <summary>
    /// Name of a bike type
    /// </summary>
    [Column("type_name")]
    public string TypeName { get; set; } = string.Empty;

    /// <summary>
    /// Price per hour of rent
    /// </summary>
    [Column("rent_cost")]
    public int RentCost { get; set; }
}
