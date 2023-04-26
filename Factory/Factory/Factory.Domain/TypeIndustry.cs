namespace Factory.Domain;

/// <summary>
/// Class describing type of industry
/// </summary>
public sealed class TypeIndustry
{
    /// <summary>
    /// Type ID
    /// </summary>
    public int TypeIndustryID { get; set; } 

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
