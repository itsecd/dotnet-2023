namespace StoreApp.Server.Dto;

public class StoreGetDto
{
    /// <summary>
    /// Store ID
    /// </summary>
    public int StoreId { get; set; } = -1;

    /// <summary>
    /// Store name
    /// </summary>
    public string StoreName { get; set; } = string.Empty;

    /// <summary>
    /// Store address
    /// </summary>
    public string StoreAddress { get; set; } = string.Empty;
}
