namespace EmployeeDomain;
public class VoucherType
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public List<VacationVoucher> VacationVoucher { get; set; }
}
