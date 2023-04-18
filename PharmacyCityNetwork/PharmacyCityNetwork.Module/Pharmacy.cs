namespace PharmacyCityNetwork;

/// <summary>
/// Сlass describing a pharmancy
/// </summary>
public class Pharmacy
{
    /// <summary>
    /// Unique id of pharmacy
    /// </summary>
    public int PharmacyId { get; set; } = 0;
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
    public List<ProductPharmacy> ProductPharmacy { get; set; } = new List<ProductPharmacy>();
    public Pharmacy() { }
    public Pharmacy(string pharmancyName, string pharmancyPhone, string pharmancyAddress, string pharmancyDirector)
    {
        PharmacyName = pharmancyName;
        PharmacyPhone = pharmancyPhone;
        PharmacyAddress = pharmancyAddress;
        PharmacyDirector = pharmancyName;
    }
}