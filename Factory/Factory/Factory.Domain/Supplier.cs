using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Domain;

/// <summary>
/// Class describing supplier
/// </summary>
public class Supplier
{
    /// <summary>
    /// Supplier's name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///  Address
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Phone 
    /// </summary>
    public string Phone { get; set; } = string.Empty;   
   
    public Supplier() { }

    public Supplier (string name, string address, string phone) 
    {
        Name = name;    
        Address = address;
        Phone = phone;
    } 
}
