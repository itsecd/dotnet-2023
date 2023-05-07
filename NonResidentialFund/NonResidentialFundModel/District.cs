using System.ComponentModel.DataAnnotations;

namespace NonResidentialFund.Model;
/// <summary>
/// District - a class that describes characteristics of a district in which the buildings are located
/// </summary>
public class District
{
    /// <summary>
    /// DistrictId - the id of the district
    /// </summary>
    [Key]
    public int DistrictId { get; set; }

    /// <summary>
    /// DistrictName - district's name
    /// </summary>
    public string DistrictName { get; set; } = string.Empty;

    public District() { }

    public District(int districtId, string districtName)
    {
        DistrictId = districtId;
        DistrictName = districtName;
    }
}

