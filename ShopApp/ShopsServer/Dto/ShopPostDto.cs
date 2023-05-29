namespace ShopsServer.Dto;
/// <summary>
/// Class ShopPostDto is used to make HTTP POST request.
/// </summary>
public class ShopPostDto
{
    /// <summary>
    /// Shop name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Shop address
    /// </summary>
    public string Address { get; set; } = string.Empty;
}
