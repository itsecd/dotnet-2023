namespace Factory.Server.Dto;

/// <summary>
/// Class describing supplier
/// </summary>
public class SupplierPostDto
{
    /// <summary>
    /// Supplier's name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///  Address
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Phone 
    /// </summary>
    public string Phone { get; set; } = string.Empty;
}
