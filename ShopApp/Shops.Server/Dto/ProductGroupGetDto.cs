namespace Shops.Server.Dto;

public class ProductGroupGetDto
{
    /// <summary>
    /// Product group id
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Name product group
    /// </summary>
    public string GroupName { get; set; } = string.Empty;
}
