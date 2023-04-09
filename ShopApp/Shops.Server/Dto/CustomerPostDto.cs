namespace Shops.Server.Dto;
/// <summary>
/// Class CustomerPostDto is used to make HTTP POST request.
/// </summary>
public class CustomerPostDto
{
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
