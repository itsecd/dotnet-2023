namespace RentalService.Domain;

/// <summary>
///     class RefundInformation contains all the information about the return of the car
/// </summary>
public class RefundInformation
{
    /// <summary>
    ///     Id - unique client identifier
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    ///     RefundPointId - identifier of the rental point
    /// </summary>
    public ulong RentalPointId { get; set; }

    /// <summary>
    ///     RefundDate - when the car was rented
    /// </summary>
    public DateTime RefundDate { get; set; } = DateTime.MinValue;

    /// <summary>
    ///     IssuedCarId - identifier of the machine that contains information about the return
    /// </summary>
    public ulong IssuedCarId { get; set; }
}