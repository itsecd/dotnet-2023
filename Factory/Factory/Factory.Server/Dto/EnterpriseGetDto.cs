namespace Factory.Server.Dto;

/// <summary>
/// Class describing factory
/// </summary>
public class EnterpriseGetDto
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
    /// Industry Type ID
    /// </summary>
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
    public int OwnershipFormID { get; set; } = 0;

    /// <summary>
    /// Employees count
    /// </summary>
    public int EmployeesCount { get; set; } = 0;

    /// <summary>
    /// Total Area
    /// </summary>
    public double TotalArea { get; set; } = 0.0;
}
