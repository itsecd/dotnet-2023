namespace Fabrics.Server.Dto;
/// <summary>
/// Class ProviderPostDto is used to make HTTP POST request.
/// </summary>
public class ProviderPostDto
{
    /// <summary>
    /// Name is used to store name of Provider.
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// TypeOfGoods is used to store product type information.
    /// </summary>
    public string TypeOfGoods { get; set; } = string.Empty;
    /// <summary>
    /// PhoneNumber is used to store phone number of Fabric.
    /// </summary>
    public string Address { get; set; } = string.Empty;
}