using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a pharmancy
/// </summary>
public class Pharmacy
{
    /// <summary>
    /// Id of pharmacy
    /// </summary>
    [Key]
    [Column("id")] 
    public int Id { get; set; } = 0;
    /// <summary>
    /// Pharmacy name
    /// </summary>
    [Column("pharmacyName")]
    public string PharmacyName { get; set; } = string.Empty;
    /// <summary>
    /// Pharmacy phone
    /// </summary>
    [Column("pharmacyPhone")] 
    public string PharmacyPhone { get; set; } = string.Empty;
    /// <summary>
    /// Pharmacy address
    /// </summary>
    [Column("pharmacyAddress")]
    public string PharmacyAddress { get; set; } = string.Empty;
    /// <summary>
    /// Pharmacy director
    /// </summary>
    [Column("pharmacyDirector")]
    public string PharmacyDirector { get; set; } = string.Empty;
    /// <summary>
    /// ProductPharmacys of pharmacy
    /// </summary>
    public List<ProductPharmacy> ProductPharmacys { get; set; } = new List<ProductPharmacy>();
    public Pharmacy() { }
    public Pharmacy(int id, string pharmacyName, string pharmacyPhone, string pharmacyAddress, string pharmacyDirector)
    {
        Id = id;
        PharmacyName = pharmacyName;
        PharmacyPhone = pharmacyPhone;
        PharmacyAddress = pharmacyAddress;
        PharmacyDirector = pharmacyDirector;
    }
}