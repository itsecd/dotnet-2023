namespace CarSharingServer.Dto;
/// <summary>
/// CarGetDto for HTTP GET request
/// </summary>
public class CarGetDto
{
    /// <summary>
    /// model of the car
    /// </summary>
    public string? Model{ get; set; }
    /// <summary>
    /// colour of the car
    /// </summary>
    public string? Colour { get; set; }
    /// <summary>
    /// identification number of car
    /// </summary>
    public int Id { get; set; }
    
}
