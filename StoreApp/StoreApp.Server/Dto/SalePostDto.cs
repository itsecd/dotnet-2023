namespace StoreApp.Server.Dto;

public class SalePostDto
{
    /// <summary>
    /// Date and time of sale
    /// </summary>
    public DateTime DateSale { get; set; } = new DateTime(1970, 1, 1);

    /// <summary>
    /// Customer
    /// </summary>
    public int CustomerId { get; set; } = -1;

    /// <summary>
    /// Store
    /// </summary>
    public int StoreId { get; set; } = -1;

    /// <summary>
    /// List of products purchased by the customer 
    /// </summary>
    public List<int> Products { get; set; } = new List<int>();

    /// <summary>
    /// Purchase amount
    /// </summary>
    public double Sum { get; set; } = 0.0;
}
