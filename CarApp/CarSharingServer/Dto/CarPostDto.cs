namespace CarSharingServer.Dto;
/// <summary>
/// CarPostDto for HTTP POST request
/// </summary>
public class CarPostDto
{
    /// <summary>
    /// model of the car
    /// </summary>
    public string? Model { get; set; } 
    /// <summary>
    /// colour of the car
    /// </summary>
    public string? Colour { get; set; }
    /// <summary>
    /// number of the car
    /// </summary>
    public string? Number { get; set; }
}
