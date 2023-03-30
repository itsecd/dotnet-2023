namespace ApplicationsServer.DTO;

/// <summary>
/// Company - a class that describes the company representative
/// </summary>
public class CompanyGetDTO
{
    /// <summary>
    /// CompanyName - a string that stores the company name
    /// </summary>  
    public string CompanyName { set; get; } = string.Empty;
    /// <summary>
    /// ContactName - the string responsible for the name of the company representative
    /// </summary>  
    public string ContactName { set; get; } = string.Empty;
    /// <summary>
    /// Telephone - a string that stores the phone number
    /// </summary>
    public string Telephone { set; get; } = string.Empty;
    /// <summary>  
    /// id - shows the company's id
    /// </summary>  
    public int Id { set; get; }
    /// <summary>
    /// Applications - shows the applications id's
    /// </summary>
    public List<int> ApplicationsIds { set; get; } = new List<int>();
}

