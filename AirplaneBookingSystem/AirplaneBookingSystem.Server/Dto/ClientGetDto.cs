namespace AirplaneBookingSystem.Server.Dto;
public class ClientGetDto
{
    /// <summary>
    /// Unique Id of client
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Client`s passport number 
    /// </summary>
    public string PassportNumber { get; set; } = string.Empty;
    /// <summary>
    /// Client`s birthday
    /// </summary>
    public DateTimeOffset BirthdayData { get; set; } = new DateTimeOffset();
    /// <summary>
    /// Client`s name
    /// </summary>
    public string Name { get; set; } = string.Empty;
}