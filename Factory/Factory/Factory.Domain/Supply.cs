using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Domain;

/// <summary>
/// Class describing supplying
/// </summary>
public class Supply
{
    /// <summary>
    /// Date
    /// </summary>
    public DateTime Date { get; set; } = new DateTime(1970, 1, 1);

    /// <summary>
    /// Goods count
    /// </summary>
    public int Quantity { get; set; } = 0;

    /// <summary>
    /// Supplier's phone number
    /// </summary>
    public string SupplierNumber { get; set; } = string.Empty; 

    public Supply() { }

    public Supply(string date, int quantity, string supplierNumber)
    {
        Date = DateTime.Parse(date);   
        Quantity = quantity;
        SupplierNumber = supplierNumber;
    }
}
