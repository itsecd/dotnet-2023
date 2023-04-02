namespace CarSharingServer.Dto;

public class ClientPostDto
{
    /// <summary>
    /// client's passport number
    /// </summary>
    public string? Passport { set; get; }
    /// <summary>
    /// client's birthday date
    /// </summary>
    public DateTime BirthDate { set; get; } 
    /// <summary>
    /// client's fist name
    /// </summary>
    public string? FirstName { set; get; }
    /// <summary>
    /// client's last name
    /// </summary>
    public string? LastName { set; get; } 
}
