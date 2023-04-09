namespace OrganizationServer.Dto;
/// <summary>
/// VoucherType - represents a type of vacation voucher, e.g. "sanatorium", "vacation home", etc.
/// </summary>
public class PostVoucherTypeDto
{
    /// <summary>
    /// Name - a name of a VoucherType
    /// </summary>
    public string? Name { get; set; }
}