using System.Collections.Generic;

namespace Factory.Domain;

/// <summary>
/// Class describing factory
/// </summary>
public class Enterprise
{
    /// <summary>
    /// Enterprise Identifier
    /// </summary>
    public int EnterpriseID { get; set; } = 0;

    /// <summary>
    /// RegistrationNumber
    /// </summary>
    public string RegistrationNumber { get; set; } = string.Empty;

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
    /// Telephone number
    /// </summary>
    public string TelephoneNumber { get; set; } = string.Empty;

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

    /// <summary>
    /// List of supplies
    /// </summary>
    public List<Supply> Supplies { get; set; } = new List<Supply>();

    public Enterprise() { }

    public Enterprise(int enterpriseID, string registrationNumber, string type, string name, string address, string telephoneNumber, string ownershipForm, int employeesCount, double totalArea, List<Supply> supplies)
    {
        EnterpriseID = enterpriseID;
        RegistrationNumber = registrationNumber;
        Type = type;
        Name = name;
        Address = address;
        TelephoneNumber = telephoneNumber;
        OwnershipForm = ownershipForm;
        EmployeesCount = employeesCount;
        TotalArea = totalArea;
        Supplies = supplies;
    }
}
