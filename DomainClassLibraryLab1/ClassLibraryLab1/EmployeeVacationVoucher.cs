namespace EmployeeDomain;
public class EmployeeVacationVoucher
{
    public uint Id { get; set; }
    public Employee? Employee { get; set; }
    public VacationVoucher? VacationVoucher { get; set; }
}
