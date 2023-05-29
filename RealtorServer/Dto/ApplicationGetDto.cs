namespace RealtorServer.Dto;

public class ApplicationGetDto
{
    /// <summary>
    /// Id -int typed value for storing Id of the room
    /// </summary>
    public int Id { get; set; } = int.MinValue;
    /// <summary>
    /// Type - string typed value representing a type of the room
    /// </summary>
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// Cost - uint for storing a cost of the room
    /// </summary>
    public uint Cost { get; set; } = uint.MinValue;
    /// <summary>
    /// Data - DateTime typed value for storing a date of application
    /// </summary>
    public DateTime Data { get; set; } = DateTime.MinValue;
}
