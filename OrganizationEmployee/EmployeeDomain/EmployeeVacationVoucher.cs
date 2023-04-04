namespace OrganizationEmployee.EmployeeDomain;
/// <summary>
/// class EmployeeVacationVoucher - represents a many-to-many relationship between Employee and VacationVoucher
/// </summary>
public class EmployeeVacationVoucher
{
    /// <summary>
    /// Id - an id of the object
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// EmployeeId - an id of Employee object
    /// </summary>
    public uint? EmployeeId { get; set; }
    /// <summary>
    /// Employee - a link to Employee object, used for many-to-many relationship
    /// </summary>
    public Employee? Employee { get; set; }
    /// <summary>
    /// VacationVoucherId - an id of VacationVoucher object
    /// </summary>
    public uint? VacationVoucherId { get; set; }
    /// <summary>
    /// VacationVoucher - a link to VacationVoucher object, used for many-to-many relationship
    /// </summary>
    public VacationVoucher? VacationVoucher { get; set; }
}