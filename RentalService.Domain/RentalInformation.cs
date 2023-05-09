using System.ComponentModel.DataAnnotations.Schema;

namespace RentalService.Domain;

/// <summary>
///     class RentalInformation contains all the information about car rental
/// </summary>
[Table("rental_information")]
public class RentalInformation
{
    /// <summary>
    ///     Id - unique client identifier
    /// </summary>
    [Column("id")]
    public ulong Id { get; set; }

    /// <summary>
    ///     RentalPointId - identifier of the rental point
    /// </summary>
    [Column("rental_point_id")]
    public ulong RentalPointId { get; set; }
    
    //public RentalPoint RentalPoint { get; set; }


    /// <summary>
    ///     RentalDate - when the car was rented
    /// </summary>
    [Column("rental_date")]
    public DateTime RentalDate { get; set; } = DateTime.MinValue;

    /// <summary>
    ///     RentalPeriod - for what time the car was rented (in days)
    /// </summary>
    [Column("rental_period")]
    public ulong RentalPeriod { get; set; }

    /// <summary>
    ///     IssuedCarId - identifier of the rental car that contains the information
    /// </summary>
    [Column("issued_car_id")]
    public ulong? IssuedCarId { get; set; }
}