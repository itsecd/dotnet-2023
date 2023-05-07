using System.ComponentModel.DataAnnotations;

namespace Shops.Domain;
/// <summary>
/// Customer -  class describes the buyers
/// </summary>
public class Customer
{
    public Customer() { }
    public Customer(int id, string firstName, string lastName, string middleName, string cardCount)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        CardCount = cardCount;
    }
    /// <summary>
    /// Customer id
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Customer first name
    /// </summary>
    [Required]
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// Customer last name
    /// </summary>
    [Required]
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// Customer middle name
    /// </summary>
    [Required]
    public string MiddleName { get; set; } = string.Empty;
    /// <summary>
    /// Customer card count
    /// </summary>
    [Required]
    public string CardCount { get; set; } = string.Empty;
}
