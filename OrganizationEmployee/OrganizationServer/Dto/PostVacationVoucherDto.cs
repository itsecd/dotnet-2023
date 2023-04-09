﻿namespace OrganizationServer.Dto;
/// <summary>
/// PostVacationVoucherDto - represents a vacation voucher, that may be issued to an employee.
/// The class stores information about issue date and voucher type.
/// </summary>
public class PostVacationVoucherDto
{
    /// <summary>
    /// IssueDate - a date, when the VacationVoucher was issued
    /// </summary>
    public DateTime IssueDate { get; set; }
    /// <summary>
    /// VoucherTypeId - an id of VoucherType object
    /// </summary>
    public uint? VoucherTypeId { get; set; }
}