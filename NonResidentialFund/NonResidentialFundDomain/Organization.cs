namespace NonResidentialFund.Domain;
/// <summary>
/// Organization - a class that describes characteristics of a organization that organized the auction 
/// </summary>
public class Organization
{
    /// <summary>
    /// OrganizationId - the id of the organization
    /// </summary>
    public int OrganizationId { get; set; }
    /// <summary>
    /// OrganizationName - organization's name
    /// </summary>
    public string OrganizationName { get; set; } = string.Empty;
    public Organization() { }
    public Organization(int organizationId, string organizationName)
    {
        OrganizationId = organizationId;
        OrganizationName = organizationName;
    }
}
