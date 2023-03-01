using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace MusicMarket;

/// <summary>
/// Покупка.
/// </summary>
public class Purchase 
{
    /// <summary>
    /// ID Покупки.
    /// </summary>
    public int Id;

    /// <summary>
    /// Список товаров.
    /// </summary>
    public List<Product> Products = new();

    /// <summary>
    /// Дата совершения покупки.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Покупатель.
    /// </summary>
    public string СustomerName { get; set; } = string.Empty;

    public Purchase() { }

    public Purchase(int id, List<Product> products, DateTime date, string customerName)
    {
        Id = id;
        Products = products;
        Date = date;
        СustomerName = customerName;
       
    }
  
}
