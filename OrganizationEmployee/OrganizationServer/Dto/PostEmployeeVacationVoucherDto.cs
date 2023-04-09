namespace OrganizationServer.Dto;
/// <summary>
/// class PostEmployeeVacationVoucherDto - represents a many-to-many relationship between Employee and VacationVoucher
/// </summary>
public class PostEmployeeVacationVoucherDto
{
    /// <summary>
    /// EmployeeId - an id of Employee object
    /// </summary>
    public uint? EmployeeId { get; set; }
    /// <summary>
    /// VacationVoucherId - an id of VacationVoucher object
    /// </summary>
    public uint? VacationVoucherId { get; set; }
}