using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a product
/// </summary>
public class Product
{
    /// <summary>
    /// Id of product
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Product name
    /// </summary>
    [Column("productName")]
    public string ProductName { get; set; } = string.Empty;
    /// <summary>
    /// Product of group Id
    /// </summary>
    [Column("groupId")]
    public int GroupId { get; set; }
    /// <summary>
    /// Product of group
    /// </summary>
    public Group Group { get; set; }
    /// <summary>
    /// Product of manufacturer Id
    /// </summary>
    [Column("manufacturerId")]
    public int ManufacturerId { get; set; }
    /// <summary>
    /// Product of manufacturer
    /// </summary>
    public Manufacturer Manufacturer { get; set; }
    /// <summary>
    /// ProductPharmacys of product
    /// </summary>
    public List<ProductPharmacy> ProductPharmacys { get; set; } = new List<ProductPharmacy>();
    /// <summary>
    /// ProductPharmaGroups of product
    /// </summary>
    public List<ProductPharmaGroup> ProductPharmaGroups { get; set; } = new List<ProductPharmaGroup>();
    /// <summary>
    /// Sales of product
    /// </summary>
    public List<Sale> Sales { get; set; } = new List<Sale>();
    public Product() { }
    public Product(string productName, int id, Group group, Manufacturer manufacturer, int groupId, int manufacturerId)
    {
        ProductName = productName;
        Id = id;
        Group = group;
        Manufacturer = manufacturer;
        GroupId = groupId;
        ManufacturerId = manufacturerId;
    }
}