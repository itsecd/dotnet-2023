namespace NonResidentialFund.Server.Dto;
/// <summary>
/// BuildingPostDto - used to get information about the Building object in the post-request to create it in the database.
/// </summary>
public class BuildingPostDto
{
    /// <summary>
    /// RegistrationNumber - registration number of building
    /// </summary>
    public int RegistrationNumber { get; set; }
    /// <summary>
    /// Address - a string that store address of building
    /// </summary>
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// DistrictId - id of the district in which the building is located
    /// </summary>
    public int DistrictId { get; set; }
    /// <summary>
    /// Area - Building area
    /// </summary>
    public double Area { get; set; }
    /// <summary>
    /// FloorCount - count of floors in building
    /// </summary>
    public int FloorCount { get; set; } = 1;
    /// <summary>
    /// BuildDate - date of building construction
    /// </summary>
    public DateTime BuildDate { get; set; } = new DateTime();
}
