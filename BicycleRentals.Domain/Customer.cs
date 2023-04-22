using System.ComponentModel.DataAnnotations;

namespace BicycleRentals.Domain;
/// <summary>
/// Customer - a class describing the customer
/// </summary> 
public class Customer
{
    /// <summary>
    /// Id - shows the customer's id
    /// </summary> 
    [Key]
    public int Id { get; set; }
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
    /// <summary>
    /// Rentals - shows the Rentals 
    /// </summary>
    public List<BicycleRental> Rentals { get; set; } = new List<BicycleRental>();
}
