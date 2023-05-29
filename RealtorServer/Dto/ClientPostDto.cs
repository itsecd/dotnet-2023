namespace RealtorServer.Dto;

public class ClientPostDto
{

    /// <summary>
    /// Passport - a string representing passport number
    /// </summary>
    public string Passport { get; set; } = string.Empty;
    /// <summary>
    /// Number - a string for contact number
    /// </summary> 
    public string Number { get; set; } = string.Empty;
    /// <summary>
    /// Registration- a string for customer registration address
    /// </summary> 
    public string Registration { get; set; } = string.Empty;
    /// <summary>
    /// Name, Surname - a string for name and surname optionally
    /// </summary> 
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
}
