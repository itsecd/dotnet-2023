namespace Shops.Domain;
public class ProductGroup
{
    public ProductGroup() { }
    public ProductGroup(int id, string groupName)
    {
        Id = id;
        GroupName = groupName;
    }

    public int Id { get; set; } = 0;
    public string GroupName { get; set; } = string.Empty;   
}
