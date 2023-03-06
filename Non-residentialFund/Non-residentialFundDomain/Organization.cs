namespace Non_residentialFundDomain;
public class Organization
{
    public int OrganizationId { get; set; }
    public string OrganizationName { get; set; } = string.Empty;
    public Organization(int organizationId, string organizationName)
    {
        OrganizationId = organizationId;
        OrganizationName = organizationName;
    }
}
