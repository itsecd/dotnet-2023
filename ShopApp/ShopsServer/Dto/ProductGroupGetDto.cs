namespace ShopsServer.Dto;
/// <summary>
/// Class ProductGroupGetDto is used to make HTTP GET request.
/// </summary>
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
