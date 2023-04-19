namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a pharma group
/// </summary>
public class PharmaGroup
{
    /// <summary>
    /// Id of pharma group
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Pharma group name
    /// </summary>
    public string PharmaGroupName { get; set; } = string.Empty;
    /// <summary>
    /// ProductPharmaGroups of pharma group
    /// </summary>
    public List<ProductPharmaGroup> ProductPharmaGroups = new();
    public PharmaGroup() { }
    public PharmaGroup(string pharmaGroupName, int id)
    {
        PharmaGroupName = pharmaGroupName;
        Id = id;
    }
}