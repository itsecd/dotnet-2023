namespace NonResidentialFund.Server.Dto;
/// <summary>
/// OrganizationPostDto - used to get information about the Organization object in the post-request to create it in the database.
/// </summary>
public class OrganizationPostDto
{
    /// <summary>
    /// OrganizationName - organization's name
    /// </summary>
    public string OrganizationName { get; set; } = string.Empty;
}
