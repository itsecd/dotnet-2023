namespace RentalService.Server.Dto;

public class RentalInformationPostDto
{
    /// <summary>
    ///     RentalPointId - identifier of the rental point
    /// </summary>
    public ulong RentalPointId { get; set; }

    /// <summary>
    ///     RentalDate - when the car was rented
    /// </summary>
    public DateTime RentalDate { get; set; } = DateTime.MinValue;

    /// <summary>
    ///     RentalPeriod - for what time the car was rented (in days)
    /// </summary>
    public ulong RentalPeriod { get; set; }

    /// <summary>
    ///     IssuedCarId - identifier of the rental car that contains the information
    /// </summary>
    public ulong? IssuedCarId { get; set; }
}