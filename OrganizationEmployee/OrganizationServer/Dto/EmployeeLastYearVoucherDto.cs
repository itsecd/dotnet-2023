namespace OrganizationEmployee.Server.Dto;
/// <summary>
/// EmployeeLastYearVoucherDto - represents an employee and employee's vacation voucher, that they has received
/// </summary>
public class EmployeeLastYearVoucherDto
{
    /// <summary>
    /// RegNumber - registration number of an Employee
    /// </summary>
    public uint? RegNumber { get; set; }
    /// <summary>
    /// FirstName - first name of an Employee
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// LastName - last name of an Employee
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// VoucherTypeName - a name of a VoucherType
    /// </summary>
    public string? VoucherTypeName { get; set; }
}
