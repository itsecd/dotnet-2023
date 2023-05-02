using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a manufacturer
/// </summary>
public class Manufacturer
{
    /// <summary>
    /// Id of manufacturer
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Manufacturer name
    /// </summary>
    [Column("manufacturerName")] 
    public string ManufacturerName { get; set; } = string.Empty;
    /// <summary>
    /// Products of manufacturer
    /// </summary>
    public List<Product> Products = new();
    public Manufacturer() { }
    public Manufacturer(string manufacturerName, int id)
    {
        ManufacturerName = manufacturerName;
        Id = id;
    }
}