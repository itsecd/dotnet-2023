namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a group
/// </summary>
public class Group
{
    /// <summary>
    /// Id of group
    /// </summary>
    public int GroupId { get; set; } = 0;
    /// <summary>
    /// Group name
    /// </summary>
    public string GroupName { get; set; } = string.Empty;
    /// <summary>
    /// Products of group
    /// </summary>
    public List<Product> Products { get; set; } = new List<Product>();
    public Group() { }
    public Group(string groupName, int groupId)
    {
        GroupName = groupName;
        GroupId = groupId;
    }
}