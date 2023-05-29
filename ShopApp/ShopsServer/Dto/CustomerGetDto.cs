namespace ShopsServer.Dto;
/// <summary>
/// Class CustomerGetDto is used to make HTTP GET request.
/// </summary>
public class CustomerGetDto
{
    /// <summary>
    /// Customer id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Customer first name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// Customer last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// Customer middle name
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;
    /// <summary>
    /// Customer card count
    /// </summary>
    public string CardCount { get; set; } = string.Empty;
}
