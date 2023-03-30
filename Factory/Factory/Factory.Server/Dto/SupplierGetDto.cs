using Factory.Domain;

namespace Factory.Server.Dto;

public class SupplierGetDto
{
    public int SupplierID { get; set; } = 0;

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

   // public List<Supply> Supplies { get; set; } = new List<Supply>();
}
