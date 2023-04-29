namespace BicycleRentals.Server.Dto;

public class CustomerPostDto
{
    /// <summary>
    /// FullName - shows the customer's name
    /// </summary> 
    public string? FullName { get; set; }
    /// <summary>
    /// BirthYear - shows the customer's Year of Birth
    /// </summary> 
    public int BirthYear { get; set; }
    /// <summary>
    /// Phone - shows the customer's telephone
    /// </summary> 
    public string? Phone { get; set; }
}
