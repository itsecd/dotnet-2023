namespace RentalService.Domain;

/// <summary>
/// class IssuedCar stores all records of rented cars
/// </summary>
public class IssuedCar
{
    /// <summary>
    /// Id - unique client ID
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    /// VehicleId - ID of the rented car
    /// </summary>
    public ulong VehicleId { get; set; }

    /// <summary>
    /// ClientId - ID of the client
    /// </summary>
    public ulong ClientId { get; set; }

    /// <summary>
    /// RentalInformationId - ID of the rental information 
    /// </summary>
    public ulong RentalInformationId { get; set; }

    /// <summary>
    /// RefundInformationId - ID of the refund information
    /// </summary>
    public ulong RefundInformationId { get; set; }
}
