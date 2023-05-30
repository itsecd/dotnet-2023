namespace CarSharingServer.Dto;
/// <summary>
/// RentedCarGetDto for HTTP GET request
/// </summary>
public class RentedCarGetDto
{

    /// <summary>
    /// identification number of rented car
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// id of rental point, where a car was rented
    /// </summary>
    public int RentalPointId { get; set; }
    /// <summary>
    /// id of model of rented car
    /// </summary>
    public int CarId { get; set; }
    /// <summary>
    /// date and time when client rented a car
    /// </summary>
    public DateTime TimeOfRent { get; set; } = DateTime.MinValue;
    /// <summary>
    /// period of time when the client can use a rented car 
    /// </summary>
    public int RentPeriod { get; set; } = 0;
    /// <summary>
    /// a day when car must be returned to the rental point
    /// </summary>
    public DateTime TimeOfReturn { get; set; } = DateTime.MinValue;
}
