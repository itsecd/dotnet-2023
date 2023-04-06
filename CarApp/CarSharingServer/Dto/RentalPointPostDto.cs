namespace CarSharingServer.Dto;
/// <summary>
/// RentalPointPostDto for HTTP POST request
/// </summary>
public class RentalPointPostDto
{
    /// <summary>
    /// name of the rental point
    /// </summary>
    public string? PointName { get; set; }
    /// <summary>
    /// address of the rental point
    /// </summary>
    public string? PointAddress { get; set; }
}
