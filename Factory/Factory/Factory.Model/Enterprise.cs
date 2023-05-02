using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Model;

/// <summary>
/// Class describing factory
/// </summary>
public class Enterprise
{
    /// <summary>
    /// Enterprise Identifier
    /// </summary>
    [Key]
    public int EnterpriseID { get; set; } = 0;

    /// <summary>
    /// RegistrationNumber
    /// </summary>
    public string RegistrationNumber { get; set; } = string.Empty;

    /// <summary>
    /// Industry Type ID
    /// </summary>
    [ForeignKey("TypeIndustry")]
    public int TypeID { get; set; } = 0;

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
    /// Ownership form ID
    /// </summary>
    [ForeignKey("OwnershipForm")]
    public int OwnershipFormID { get; set; } = 0;

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
    public List<Supply> Supplies { get; set; } = null!;

    public Enterprise() { }

    public Enterprise(int enterpriseID, string registrationNumber, int typeID, string name, string address, string telephoneNumber, int ownershipFormID, int employeesCount, double totalArea)
    {
        EnterpriseID = enterpriseID;
        RegistrationNumber = registrationNumber;
        TypeID = typeID;
        Name = name;
        Address = address;
        TelephoneNumber = telephoneNumber;
        OwnershipFormID = ownershipFormID;
        EmployeesCount = employeesCount;
        TotalArea = totalArea;
        Supplies = new List<Supply>();
    }
}
