namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a sale
/// </summary>
public class Sale
{
    /// <summary>
    /// Id of sale
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Payment choice
    /// </summary>
    public string PaymentChoice { get; set; } = string.Empty;
    /// <summary>
    /// Payment date
    /// </summary>
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    /// <summary>
    /// Product
    /// </summary>
    public Product Product { get; set; }
    public Sale() { }
    public Sale(string paymentChoice, DateTime paymentDate, Product product)
    {
        PaymentChoice = paymentChoice;
        PaymentDate = paymentDate;
        Product = product;
    }
}