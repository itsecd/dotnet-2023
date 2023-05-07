using System.ComponentModel.DataAnnotations;

namespace NonResidentialFund.Model;
/// <summary>
/// Organization - a class that describes characteristics of a organization that organized the auction 
/// </summary>
public class Organization
{
    /// <summary>
    /// OrganizationId - the id of the organization
    /// </summary>
    [Key]
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
