namespace StoreApp.Domain;

/// <summary>
/// Customer - Class describing the buyer
/// </summary>
public class Customer
{
    /// <summary>
    /// Full name of customer
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Customer card number
    /// </summary>
    public int CustomerCardNumber { get; set; } = -1;


    public Customer(string customerName, int customerCardNumber)
    {
        CustomerName = customerName;
        CustomerCardNumber = customerCardNumber;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Customer param)
            return false;

        return CustomerName == param.CustomerName &&
               CustomerCardNumber == param.CustomerCardNumber;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CustomerName, CustomerCardNumber);
    }
}

