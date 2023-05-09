namespace NonResidentialFund.Server.Dto;
/// <summary>
/// DistrictGetDto - used to represent the District object in the get-request.
/// </summary>
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
