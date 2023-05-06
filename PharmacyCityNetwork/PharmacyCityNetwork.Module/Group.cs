using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a group
/// </summary>
[Table("groups")]
public class Group
{
    /// <summary>
    /// Id of group
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Group name
    /// </summary>
    [Column("groupName")]
    public string GroupName { get; set; } = string.Empty;
    /// <summary>
    /// Products of group
    /// </summary>
    public List<Product> Products { get; set; } = new List<Product>();
    public Group() { }
    public Group(string groupName, int id)
    {
        GroupName = groupName;
        Id = id;
    }
}