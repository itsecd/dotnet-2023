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
    /// Quantity
    /// </summary>
    public int Quantity { get; set; } = 0;

    public Supply() { }

    public Supply(DateTime date, int quantity)
    {
        Date = date;   
        Quantity = quantity;
    }
}
