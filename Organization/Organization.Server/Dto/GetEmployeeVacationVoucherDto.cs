namespace Organization.Server.Dto;
/// <summary>
/// class PostEmployeeVacationVoucherDto - represents a many-to-many relationship between Employee and VacationVoucher
/// </summary>
public class GetEmployeeVacationVoucherDto
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
    /// VacationVoucherId - an id of VacationVoucher object
    /// </summary>
    public uint? VacationVoucherId { get; set; }
}