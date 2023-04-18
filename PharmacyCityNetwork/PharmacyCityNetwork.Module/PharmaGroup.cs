namespace PharmacyCityNetwork;

/// <summary>
/// Сlass describing a pharma group
/// </summary>
public class PharmaGroup
{
    /// <summary>
    /// Unique id of pharma group
    /// </summary>
    public int PharmaGroupId { get; set; } = 0;
    /// <summary>
    /// Pharma group name
    /// </summary>
    public string PharmaGroupName { get; set; } = string.Empty;
    /// <summary>
    /// ProductPharmaGroup of pharma group
    /// </summary>
    public List<ProductPharmaGroup> ProductPharmaGroup = new();
    public PharmaGroup() { }
    public PharmaGroup(string pharmaGroupName, int pharmaGroupId)
    {
        PharmaGroupName = pharmaGroupName;
        PharmaGroupId = pharmaGroupId;
    }
}