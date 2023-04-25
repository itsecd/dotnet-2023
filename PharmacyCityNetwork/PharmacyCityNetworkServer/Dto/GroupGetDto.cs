namespace PharmacyCityNetwork.Server.Dto;

public class GroupGetDto
{
    /// <summary>
    /// Id of group
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Group name
    /// </summary>
    public string GroupName { get; set; } = string.Empty;
}
