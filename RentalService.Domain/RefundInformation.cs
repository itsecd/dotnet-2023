using System.ComponentModel.DataAnnotations.Schema;

namespace RentalService.Domain;

/// <summary>
///     class RefundInformation contains all the information about the return of the car
/// </summary>
[Table("refund_information")]
public class RefundInformation
{
    /// <summary>
    ///     Id - unique client identifier
    /// </summary>
    [Column("id")]
    public ulong Id { get; set; }

    /// <summary>
    ///     RefundPointId - identifier of the rental point
    /// </summary>
    [Column("rental_point_id")]
    public ulong RentalPointId { get; set; }

    //public RentalPoint RentalPoint { get; set; }

    /// <summary>
    ///     RefundDate - when the car was rented
    /// </summary>
    [Column("refund_date")]
    public DateTime RefundDate { get; set; } = DateTime.MinValue;

    /// <summary>
    ///     IssuedCarId - identifier of the machine that contains information about the return
    /// </summary>
    [Column("issued_car_id")]
    public ulong? IssuedCarId { get; set; }
}