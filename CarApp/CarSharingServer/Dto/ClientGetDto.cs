namespace CarSharingServer.Dto;

public class ClientGetDto
{
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
