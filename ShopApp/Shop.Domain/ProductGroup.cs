namespace Shops.Domain;
/// <summary>
/// Product - class describing product groups
/// </summary>
public class ProductGroup
{
    public ProductGroup() { }
    public ProductGroup(int id, string groupName)
    {
        Id = id;
        GroupName = groupName;
    }
    /// <summary>
    /// Product group id
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Name product group
    /// </summary>
    public string GroupName { get; set; } = string.Empty;
}
