namespace OrganizationServer.DTO;
using EmployeeDomain;
/// <summary>
/// VacationVoucher - represents a vacation voucher, that may be issued to an employee.
/// The class stores information about issue date, voucher type and also list of EmployeeVacationVoucher in
/// order to maintain many-to-many relationship.
/// </summary>
public class VacationVoucherDTO
{
    /// <summary>
    /// Id - an id of a VacationVoucher
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// IssueDate - a date, when the VacationVoucher was issued
    /// </summary>
    public DateTime IssueDate { get; set; }
    /// <summary>
    /// VoucherTypeId - an id of VoucherType object
    /// </summary>
    public uint? VoucherTypeId { get; set; }
}