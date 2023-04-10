namespace Shops.Server.Dto;
/// <summary>
/// Class ShopGetDto is used to make HTTP GET request.
/// </summary>
public class ShopGetDto
{
    /// <summary>
    /// Shop id
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Shop name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Shop address
    /// </summary>
    public string Address { get; set; } = string.Empty;
}
