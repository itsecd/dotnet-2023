namespace RentalService.Domain;

/// <summary>
///     class IssuedCar stores all records of rented cars
/// </summary>
public class IssuedCar
{
    /// <summary>
    ///     Id - unique client identifier
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    ///     VehicleId - identifier of the rented car
    /// </summary>
    public ulong VehicleId { get; set; }
    
    public Vehicle Vehicles{ get; set; }

    /// <summary>
    ///     ClientId - identifier  of the client
    /// </summary>
    public ulong ClientId { get; set; }
    
    public Client Client{ get; set; }

    /// <summary>
    ///     RentalInformationId - identifier of the rental information
    /// </summary>
    public ulong RentalInformationId { get; set; }
    

    /// <summary>
    ///     RefundInformationId - identifier of the refund information
    /// </summary>
    public ulong? RefundInformationId { get; set; }
    
}