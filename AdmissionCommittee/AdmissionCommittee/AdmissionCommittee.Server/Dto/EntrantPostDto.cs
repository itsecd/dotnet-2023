namespace AdmissionCommittee.Server.Dto;
/// <summary>
/// Information about entrants
/// </summary>
public class EntrantPostDto
{
    /// <summary>
    /// FullName - string value for storing the entrant's full name
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// DateBirth - DateTime value for storing the entrant's date of birth
    /// </summary>
    public DateTime DateBirth { get; set; }

    /// <summary>
    /// Country - string value for storing the entrant's country
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// City - string value for storing the entrant's city
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// StatementId - int value for storing the id statement of entrant
    /// </summary>
    public int StatementId { get; set; }
}