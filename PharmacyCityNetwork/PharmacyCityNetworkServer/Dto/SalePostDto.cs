namespace PharmacyCityNetwork.Server.Dto;

public class SalePostDto
{
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
    public int ProductId { get; set; }
}
