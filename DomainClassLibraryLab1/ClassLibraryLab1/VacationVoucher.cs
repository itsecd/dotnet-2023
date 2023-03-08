namespace EmployeeDomain;
public class VacationVoucher
{
    public uint Id { get; set; }
    public DateOnly IssueDate { get; set; }
    public VoucherType VoucherType { get; set; }
    public List<EmployeeVacationVoucher> EmployeeVacationVoucher { get; set; }
}
