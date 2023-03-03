using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Domain;

/// <summary>
/// Class describing district management
/// </summary>
public class DistrictManagement
{
    /// <summary>
    /// List of factories
    /// </summary>
    public List<Factory> Factories { get; set; } = new List<Factory>();   
    
    /// <summary>
    /// List of suppliers
    /// </summary>
    public List<Supplier> Suppliers { get; set; } = new List<Supplier>();

    /// <summary>
    /// List of supplies
    /// </summary>
    public List<Supply> Supplies { get; set; } = new List<Supply>();

    public DistrictManagement() { }

    public DistrictManagement(List<Factory> factories, List<Supplier> suppliers, List<Supply> supplies)
    {
        Factories = factories;
        Suppliers = suppliers;
        Supplies = supplies;
    }
}
