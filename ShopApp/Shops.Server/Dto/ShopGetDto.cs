namespace Shops.Server.Dto;

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
    public string Adress { get; set; } = string.Empty;
}
