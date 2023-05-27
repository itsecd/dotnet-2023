using Organization.Domain;
namespace Organization.Server.Repository;

public interface IOrganizationRepository
{
    public List<Workshop> Workshops { get; }
    public List<Department> Departments { get; }
    public List<VoucherType> VoucherTypes { get; }
    public List<VacationVoucher> VacationVouchers { get; }
    public List<Occupation> Occupations { get; }
    public List<Employee> Employees { get; }
    public List<Employee> EmployeesWithDepartmentEmployeeFilled { get; }
    public List<DepartmentEmployee> DepartmentEmployees { get; }
    public List<EmployeeVacationVoucher> EmployeeVacationVouchers { get; }
    public List<EmployeeOccupation> EmployeeOccupations { get; }
}
