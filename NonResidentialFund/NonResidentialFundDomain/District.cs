namespace NonResidentialFund.Domain;
/// <summary>
/// District - a class that describes characteristics of a district in which the buildings are located
/// </summary>
public class District
{
    /// <summary>
    /// DistrictId - the id of the district
    /// </summary>
    public int DistrictId { get; set; }
    /// <summary>
    /// DistrictName - district's name
    /// </summary>
    public string DistrictName { get; set; } = string.Empty;
    public District(int districtId, string districtName)
    {
        DistrictId = districtId;
        DistrictName = districtName;
    }
}

