namespace OrganizationEmployee.Server.Dto;
/// <summary>
/// Class PostWorkshopDto represents a workshop on the organization
/// </summary>
public class GetWorkshopDto
{
    /// <summary>
    /// Id - an id of the workshop
    /// </summary>
    public uint? Id { get; set; }
    /// <summary>
    /// Name - a name of the workshop
    /// </summary>
    public string? Name { get; set; }
}