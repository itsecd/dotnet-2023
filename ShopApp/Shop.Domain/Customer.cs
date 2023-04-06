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
    public int Id { get; set; }
    /// <summary>
    /// Customer first name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// Customer last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// Customer middle name
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;
    /// <summary>
    /// Customer card count
    /// </summary>
    public string CardCount { get; set; } = string.Empty;
}
