using System.ComponentModel.DataAnnotations;

namespace Factory.Domain;

/// <summary>
/// Class describing type of industry
/// </summary>
public sealed class TypeIndustry
{
    /// <summary>
    /// Type ID
    /// </summary>
    [Key]
    public int TypeIndustryID { get; set; } = 0;

    /// <summary>
    /// Type name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public TypeIndustry() { }

    public TypeIndustry(int typeID, string name)
    {
        TypeIndustryID = typeID;
        Name = name;
    }
}
