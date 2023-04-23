namespace PharmacyCityNetwork.Server.Dto;

public class SaleGetDto
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
    public int ProductId { get; set; }
}
