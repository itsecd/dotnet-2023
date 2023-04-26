namespace Factory.Server.Dto;

/// <summary>
/// Class describing type of industry
/// </summary>
public class TypeIndustryGetDto
{
    /// <summary>
    /// Type ID
    /// </summary>
    public int TypeIndustryID { get; set; }

    /// <summary>
    /// Type name
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
