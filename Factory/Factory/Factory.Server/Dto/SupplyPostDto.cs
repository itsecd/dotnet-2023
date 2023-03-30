namespace Factory.Server.Dto;

public class SupplyPostDto
{
    public int EnterpriseID { get; set; } = 0;

    public int SupplierID { get; set; } = 0;

    public DateTime Date { get; set; } = new DateTime(1970, 1, 1);

    public int Quantity { get; set; } = 0;
}
