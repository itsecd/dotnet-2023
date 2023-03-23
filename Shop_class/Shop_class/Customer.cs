namespace Shop_class;
/// <summary>
/// Customer -  class describes the buyers
/// </summary>
public class Customer
{
    public Customer(int customerId, string firstName, string lastName, string middleName, string cardCount)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        CardCount = cardCount;
    }
    /// <summary>
    /// Customer id
    /// </summary>
    public int CustomerId { get; set; }
    /// <summary>
    /// Customer first name
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Customer last name
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Customer midle name
    /// </summary>
    public string MiddleName { get; set; }
    /// <summary>
    /// Customer card count
    /// </summary>
    public string CardCount { get; set; }
}
