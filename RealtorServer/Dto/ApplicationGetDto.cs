namespace RealtorServer.Dto;
/// <summary>
/// ApplicationGetDto for HTTP GET request
/// </summary>
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
    /// <summary>
    /// ClientId - int typed value for storing Id of the client
    /// </summary>
    public int ClientId { get; set; }=int.MinValue;
}
