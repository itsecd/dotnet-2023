namespace NonResidentialFund.Server.Dto;

public class DistrictGetDto
{
    /// <summary>
    /// DistrictId - the id of the district
    /// </summary>
    public int DistrictId { get; set; }
    /// <summary>
    /// DistrictName - district's name
    /// </summary>
    public string DistrictName { get; set; } = string.Empty;
}
