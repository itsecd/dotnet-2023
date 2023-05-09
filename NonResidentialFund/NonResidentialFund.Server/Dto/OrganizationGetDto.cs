namespace NonResidentialFund.Server.Dto;
/// <summary>
/// OrganizationGetDto - used to represent the Organization object in the get-request.
/// </summary>
public class OrganizationGetDto
{
    /// <summary>
    /// OrganizationId - the id of the organization
    /// </summary>
    public int OrganizationId { get; set; }
    /// <summary>
    /// OrganizationName - organization's name
    /// </summary>
    public string OrganizationName { get; set; } = string.Empty;
}
