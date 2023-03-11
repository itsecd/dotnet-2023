namespace AdmissionCommittee;
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
    public string FullName { get; set; }

    /// <summary>
    /// DateBirth - DateTime value for storing the entrant's date of birth
    /// </summary>
    public DateTime DateBirth { get; set; }

    /// <summary>
    /// Country - string value for storing the entrant's country
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// City - string value for storing the entrant's city
    /// </summary>
    public string City { get; set; }

    public Statement Statement { get; set; }

    public List<Result> Results = new();

    public Entrant(int idEntrant, string fullName, DateTime dateBirth, string country, string city, Statement statement)
    {
        IdEntrant = idEntrant;
        FullName = fullName;
        DateBirth = dateBirth;
        Country = country;
        City = city;
        Statement = statement;
    }

    public Entrant(int idEntrant, string fullName, DateTime dateBirth, string country, string city, Statement statement, List<Result> results) : this(idEntrant, fullName, dateBirth, country, city, statement)
    {
        Results = results;
    }
}
