namespace NonResidentialFund.Server.Dto;
/// <summary>
/// DistrictPostDto - used to get information about the District object in the post-request to create it in the database.
/// </summary>
public class DistrictPostDto
{
    /// <summary>
    /// DistrictName - district's name
    /// </summary>
    public string DistrictName { get; set; } = string.Empty;
}
