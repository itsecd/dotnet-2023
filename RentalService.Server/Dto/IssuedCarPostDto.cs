namespace RentalService.Server.Dto;

public class IssuedCarPostDto
{
    /// <summary>
    ///     VehicleId - identifier of the rented car
    /// </summary>
    public ulong VehicleId { get; set; }

    /// <summary>
    ///     ClientId - identifier  of the client
    /// </summary>
    public ulong ClientId { get; set; }

    /// <summary>
    ///     RentalInformationId - identifier of the rental information
    /// </summary>
    public ulong RentalInformationId { get; set; }

    /// <summary>
    ///     RefundInformationId - identifier of the refund information
    /// </summary>
    public ulong? RefundInformationId { get; set; }
}