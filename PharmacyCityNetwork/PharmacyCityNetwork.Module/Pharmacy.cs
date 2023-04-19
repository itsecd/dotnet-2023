namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a pharmancy
/// </summary>
public class Pharmacy
{
    /// <summary>
    /// Id of pharmacy
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Pharmacy name
    /// </summary>
    public string PharmacyName { get; set; } = string.Empty;
    /// <summary>
    /// Pharmacy phone
    /// </summary>
    public string PharmacyPhone { get; set; } = string.Empty;
    /// <summary>
    /// Pharmacy address
    /// </summary>
    public string PharmacyAddress { get; set; } = string.Empty;
    /// <summary>
    /// Pharmacy director
    /// </summary>
    public string PharmacyDirector { get; set; } = string.Empty;
    /// <summary>
    /// ProductPharmacys of pharmacy
    /// </summary>
    public List<ProductPharmacy> ProductPharmacys { get; set; } = new List<ProductPharmacy>();
    public Pharmacy() { }
    public Pharmacy(string pharmacyName, string pharmacyPhone, string pharmacyAddress, string pharmacyDirector)
    {
        PharmacyName = pharmacyName;
        PharmacyPhone = pharmacyPhone;
        PharmacyAddress = pharmacyAddress;
        PharmacyDirector = pharmacyDirector;
    }
}