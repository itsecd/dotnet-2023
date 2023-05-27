using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Domain;
/// <summary>
/// VoucherType - represents a type of vacation voucher, e.g. "sanatorium", "vacation home", etc.
/// </summary>
public class VoucherType
{
    /// <summary>
    /// Id - an id of a VoucherType
    /// </summary>
    [Key]
    public uint Id { get; set; }
    /// <summary>
    /// Name - a name of a VoucherType
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// VacationVoucher - a list of VacationVoucher objects. For more details proceed to VacationVoucher class
    /// </summary>
    [InverseProperty("VoucherType")]
    public ICollection<VacationVoucher> VacationVouchers { get; set; }
}