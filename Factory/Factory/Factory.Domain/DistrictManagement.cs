using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Domain;

/// <summary>
/// Class describing district management
/// </summary>
public class Management
{
    /// <summary>
    /// List of factories
    /// </summary>
    public Enterprise Factory { get; set; } = new Enterprise();   
    
    /// <summary>
    /// List of suppliers
    /// </summary>
    public List<Supplier> Suppliers { get; set; } = new List<Supplier>();

    /// <summary>
    /// List of supplies
    /// </summary>
    public List<Supply> Supplies { get; set; } = new List<Supply>();

    public Management() { }

    public Management(Enterprise factory, List<Supplier> suppliers, List<Supply> supplies)
    {
        Factory = factory;
        Suppliers = suppliers;
        Supplies = supplies;
    }
}
