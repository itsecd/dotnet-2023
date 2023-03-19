namespace Shop_class;
/// <summary>
/// Customer -  class describes the buyers
/// </summary>
public class Customer
{
    public Customer(int customerid, string firstname, string lastname, string middlename, string cardcount)
    {
        CustomerId = customerid;
        FirstName = firstname;
        LastName = lastname;
        MiddleName = middlename;
        CardCount = cardcount;
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
