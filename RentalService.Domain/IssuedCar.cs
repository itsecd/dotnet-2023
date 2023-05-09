using System.ComponentModel.DataAnnotations.Schema;

namespace RentalService.Domain;

/// <summary>
///     class IssuedCar stores all records of rented cars
/// </summary>
[Table("issued_car")]
public class IssuedCar
{
    /// <summary>
    ///     Id - unique client identifier
    /// </summary>
    [Column("id")]
    public ulong Id { get; set; }

    /// <summary>
    ///     VehicleId - identifier of the rented car
    /// </summary>
    [Column("vehicle_id")]
    public ulong VehicleId { get; set; }
    
    //public Vehicle Vehicle{ get; set; }

    /// <summary>
    ///     ClientId - identifier  of the client
    /// </summary>
    [Column("client_id")]
    public ulong ClientId { get; set; }
    
    //public Client Client{ get; set; }

    /// <summary>
    ///     RentalInformationId - identifier of the rental information
    /// </summary>
    [Column("rental_information_id")]
    public ulong RentalInformationId { get; set; }
    //public RentalInformation RentalInformationN { get; set; }
    

    /// <summary>
    ///     RefundInformationId - identifier of the refund information
    /// </summary>
    [Column("refund_information_id")]
    public ulong? RefundInformationId { get; set; }
    //public RefundInformation? RefundInformationN { get; set; }
    
}