namespace CarSharingServer.Dto;

public class TopCarsGetDto
{
    /// <summary>
    /// model of the car
    /// </summary>
    public string? Model { get; set; }
    /// <summary>
    /// number of rents for each model
    /// </summary>
    public int Rating { get; set; }
}
