namespace Organization.Server.Dto;
/// <summary>
/// VoucherType - represents a type of vacation voucher, e.g. "sanatorium", "vacation home", etc.
/// </summary>
public class GetVoucherTypeDto
{
    /// <summary>
    /// Id - an id of a VoucherType
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// Name - a name of a VoucherType
    /// </summary>
    public string? Name { get; set; }
}