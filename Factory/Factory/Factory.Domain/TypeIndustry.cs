namespace Factory.Domain;

/// <summary>
/// Class describing type of industry
/// </summary>
public class TypeIndustry
{
    /// <summary>
    /// Type ID
    /// </summary>
    public int TypeID { get; set; } = 0;

    /// <summary>
    /// Type name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public TypeIndustry() { }

    public TypeIndustry(int typeID, string name)
    {
        TypeID = typeID;
        Name = name;
    }
}
