using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRental.Domain;

/// <summary>
/// Class RentRecord has the info about a bike rent: client info, rented bike info, rent time
/// </summary>
[Table("rent_record")]
public class RentRecord
{
    /// <summary>
    /// Id of a rent record
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// Id of a client who rented a bike
    /// </summary>
    [Column("client_id")]
    public int ClientId { get; set; }

    /// <summary>
    /// Connection to class Client
    /// </summary>
    public Client? Client { get; set; }

    /// <summary>
    /// Id of a rented bike
    /// </summary>
    [Column("bike_id")]
    public int BikeId { get; set; }

    /// <summary>
    /// Connection to class Bike
    /// </summary>
    public Bike? Bike { get; set; }

    /// <summary>
    /// Date and time of the start of the rent
    /// </summary>
    [Column("rent_start_time")]
    public DateTime RentStartTime { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Date and time when whe client must return a bike
    /// </summary>
    [Column("rent_end_time")]
    public DateTime RentEndTime { get; set; } = DateTime.MinValue;

}
