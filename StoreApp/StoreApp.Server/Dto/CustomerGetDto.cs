namespace StoreApp.Server.Dto;

public class CustomerGetDto
{
    /// <summary>
    /// ID of customer
    /// </summary>
    public int CustomerId { get; set; }
    /// <summary>
    /// Full name of customer
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Customer card number
    /// </summary>
    public int CustomerCardNumber { get; set; }
}
