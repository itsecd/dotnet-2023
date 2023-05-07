using System.ComponentModel.DataAnnotations;
namespace StoreApp.Model;

/// <summary>
/// Customer - Class describing the buyer
/// </summary>
public class Customer
{
    /// <summary>
    /// ID of customer
    /// </summary>
    [Key]
    public int CustomerId { get; set; }

    /// <summary>
    /// Full name of customer
    /// </summary>
    [Required]
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Customer card number
    /// </summary>
    [Required]
    public int CustomerCardNumber { get; set; } = -1;

    /// <summary>
    /// Customer sales collection
    /// </summary>
    public List<Sale> Sales { get; set; } = null!;

    public Customer() { }

    public Customer(int customerId, string customerName, int customerCardNumber)
    {
        CustomerId = customerId;
        CustomerName = customerName;
        CustomerCardNumber = customerCardNumber;
        Sales = new List<Sale>();
    }
}

