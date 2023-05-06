using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Domain;

/// <summary>
///     Class Supple is used to store info about the supplies
/// </summary>
public class Supplies
{
    /// <summary>  
    ///     Id - shows the supply id
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { set; get; }
    /// <summary>
    ///     Quantity - shows quantity of product
    /// </summary>  
    [Column("quantity")]
    public int Quantity { set; get; }
    /// <summary>
    ///     CompanyName - contain name of company what get supply
    /// </summary>
    [Column("company_name")]
    public string CompanyName { set; get; } = string.Empty;
    /// <summary>
    ///     CompanyAdress - address of the company what get supply
    /// </summary>
	[Column("company_address")]
    public string CompanyAddress { get; set; } = string.Empty;
    /// <summary>
    ///     SupplyDate - shipment date
    /// </summary>
    [Column("supply_date")]
    public DateTime SupplyDate { get; set; } = DateTime.MinValue;
    /// <summary>
    ///     Products - list of products, what shipment contains 
    /// </summary>
    public List<Products> Products { set; get; } = new List<Products>();
    public Supplies(int id, string companyName, string companyAdress, DateTime supplyDate, int quantity)
    {
        Id = id;
        CompanyName = companyName;
        CompanyAddress = companyAdress;
        SupplyDate = supplyDate;
        Quantity = quantity;
    }
    public Supplies() { }
}