using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDomain;
/// <summary>
/// VacationVoucher - represents a vacation voucher, that may be issued to an employee.
/// The class stores information about issue date, voucher type and also list of EmployeeVacationVoucher in
/// order to maintain many-to-many relationship.
/// </summary>
public class VacationVoucher
{
    /// <summary>
    /// Id - an id of a VacationVoucher
    /// </summary>
    [Key]
    public uint Id { get; set; }
    /// <summary>
    /// IssueDate - a date, when the VacationVoucher was issued
    /// </summary>
    [Required]
    public DateTime IssueDate { get; set; }
    /// <summary>
    /// VoucherTypeId - an id of VoucherType object
    /// </summary>
    [ForeignKey("VoucherType")]
    public uint? VoucherTypeId { get; set; } = 1;
    /// <summary>
    /// VoucherType - a link to VoucherType of the given voucher
    /// </summary>
    public VoucherType? VoucherType { get; set; }
    /// <summary>
    /// EmployeeVacationVoucher - a list of EmployeeVacationVoucher objects. For more details proceed to EmployeeVacationVoucher class
    /// </summary>
    public List<EmployeeVacationVoucher> EmployeeVacationVouchers { get; set; }
}