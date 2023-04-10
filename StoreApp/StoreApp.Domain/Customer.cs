namespace StoreApp.Domain;

/// <summary>
/// Customer - Class describing the buyer
/// </summary>
public class Customer
{
    /// <summary>
    /// ID of customer
    /// </summary>
    public int CustomerId { get; set; } = -1;
    /// <summary>
    /// Full name of customer
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Customer card number
    /// </summary>
    public int CustomerCardNumber { get; set; } = -1;

    /// <summary>
    /// Customer purchase ID collection
    /// </summary>
    public List<int> SalesId { get; set; } = new List<int>();

    public Customer() { }

    public Customer(int customerId, string customerName, int customerCardNumber)
    {
        CustomerId = customerId;
        CustomerName = customerName;
        CustomerCardNumber = customerCardNumber;
        SalesId = new List<int>();
    }
}

