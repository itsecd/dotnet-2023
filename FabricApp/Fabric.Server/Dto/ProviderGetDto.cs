namespace Fabrics.Server.Dto;
/// <summary>
/// Class ProviderGetDto is used to make HTTP GET request.
/// </summary>
public class ProviderGetDto
{
    /// <summary>
    /// Id is used to store the ID.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Name is used to store name of Provider.
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// TypeOfGoods is used to store product type information.
    /// </summary>
    public string TypeOfGoods { get; set; } = string.Empty;
    /// <summary>
    /// Address is used to store address of Provider.
    /// </summary>
    public string Address { get; set; } = string.Empty;
}