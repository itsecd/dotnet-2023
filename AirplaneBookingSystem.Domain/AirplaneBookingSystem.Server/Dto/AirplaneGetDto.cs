namespace AirplaneBookingSystem.Server.Dto;
public class AirplaneGetDto
{
    /// <summary>
    /// Unique Id of Airplane 
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    ///  Model of Airplane 
    /// </summary>
    public string Model { get; set; } = string.Empty;
}
