using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a sale
/// </summary>
public class Sale
{
    /// <summary>
    /// Id of sale
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; } = 0;
    /// <summary>
    /// Payment choice
    /// </summary>
    [Column("paymentChoice")]
    public string PaymentChoice { get; set; } = string.Empty;
    /// <summary>
    /// Payment date
    /// </summary>
    [Column("paymentDate")]
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    /// <summary>
    /// Product
    /// </summary>
    [Column("productId")]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public Sale() { }
    public Sale(string paymentChoice, DateTime paymentDate, Product product, int productId, int id)
    {
        PaymentChoice = paymentChoice;
        PaymentDate = paymentDate;
        Product = product;
        ProductId = productId;
        Id = id;
    }
}