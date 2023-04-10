namespace AdmissionCommittee.Model;
/// <summary>
/// Information about entrants
/// </summary>
public class Entrant
{
    /// <summary>
    /// IdEntrant - int type value for storing the id entrant
    /// </summary>
    public int IdEntrant { get; set; }

    /// <summary>
    /// FullName - string value for storing the entrant's full name
    /// </summary>
    public string FullName { get; set; } = string.Empty;

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

    /// <summary>
    /// Statement - link to statements's entrant
    /// </summary>
    public Statement? Statement { get; set; }

    /// <summary>
    /// EntrantResults - list storing relatioship between Entrant and Result
    /// </summary>
    public List<EntrantResult> EntrantResults = new();
}