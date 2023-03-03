using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Domain;

/// <summary>
/// Class describing factory
/// </summary>
public class Factory
{
    /// <summary>
    /// RegistrationNumber
    /// </summary>
    public int RegistrationNumber { get; set; } = 0;

    /// <summary>
    /// Industry Type
    /// </summary>
    public string Type { get; set; } = string.Empty;
    
    /// <summary>
    /// Factory name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Address 
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Ownership form
    /// </summary>
    public string OwnershipForm { get; set; } = string.Empty;

    /// <summary>
    /// Employees count
    /// </summary>
    public int EmployeesCount { get; set; } = 0;

    /// <summary>
    /// Total Area
    /// </summary>
    public double TotalArea { get; set; } = 0.0;

    public Factory() { }

    public Factory(int registrationNumber, string type, string name, string address, string ownershipForm, int employeesCount, double totalArea)
    {
        RegistrationNumber = registrationNumber;
        Type = type;
        Name = name;
        Address = address;
        OwnershipForm = ownershipForm;
        EmployeesCount = employeesCount;
        TotalArea = totalArea;
    }
}
