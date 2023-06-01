namespace CarSharingServer.Dto;
/// <summary>
/// RentalPointPostDto for HTTP POST request
/// </summary>
public class RentalPointPostDto
{
    /// <summary>
    /// name of the rental point
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// address of the rental point
    /// </summary>
    public string? Address { get; set; }
    /// <summary>
    /// identification number of rental point
    /// </summary>
    public int Id { get; set; }
}
