namespace EmployeeDomain;
public class Employee
{

    /// <summary>
    /// Identificator for each Employee object
    /// </summary>
    public Guid Id { get; set; } = Guid.Empty;
    /// <summary>
    /// regNumber - registration number of an Employee
    /// </summary>
    public uint regNumber = 0;
    /// <summary>
    /// FirstName - first name of an Employee
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// LastName - last name of an Employee
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// LastName - patronymic name of on Employee
    /// </summary>
    public string PatronymicName { get; set; } = string.Empty;
    /// <summary>
    /// BirthDate - birth date of an Employee
    /// </summary>
    public DateOnly BirthDate { get; set; } = DateOnly.MinValue;
    /// <summary>
    /// Workshop - an workshop, where the employee is working
    /// </summary>
    public Workshop? Workshop { get; set; }
    /// <summary>
    /// HomeAddress - home address of an employee
    /// </summary>
    public string HomeAddress { get; set; } = string.Empty;
    /// <summary>
    /// HomeTelephone - home telephone of an employee
    /// </summary>
    public string HomeTelephone { get; set; } = string.Empty;
    /// <summary>
    /// Work Telephone - work telephone of an employee
    /// </summary>
    public string WorkTelephone { get; set; } = string.Empty;
    /// <summary>
    /// FamilyStatus - family status of an employee (ex. "married", "single")
    /// </summary>
    public string FamilyStatus { get; set; } = string.Empty;
    /// <summary>
    /// FamilyMembersCount - number of people in the employee's family
    /// </summary>
    public uint FamilyMembersCount { get; set; } = 1;
    /// <summary>
    /// ChildrenCount - number of the employee's children
    /// </summary>
    public uint ChildrenCount { get; set; } = 0;
    /// <summary>
    /// EmployeeOccupation - a list of employee's occupations, including old occupations (on which the employee
    /// has been working), and active occupation. Also includes dates of hire and dismissal dates,
    /// for more details proceed to "EmployeeOccupation" class
    /// </summary>
    public List<EmployeeOccupation> EmployeeOccupation { get; set; }
    /// <summary>
    /// DepartmentEmployee - a list of employee's departments in which the employee is currently working
    /// One employee can work in multiple departments
    /// </summary>
    public List<DepartmentEmployee> DepartmentEmployee { get; set; }
    /// EmployeeVactionVoucher - a list of employee's vacation vouchers. For more details proceed to
    /// "EmployeeVacationVoucher" and "VacationVoucher"
    /// </summary>
    public List<EmployeeVacationVoucher> EmployeeVacationVoucher { get; set; }

    public Employee(Guid id, uint regNumber, string firstName, string lastName, string patronymicName, DateOnly birthDate, Workshop? workshop, string homeAddress, string homeTelephone, string workTelephone, string familyStatus, uint familyMembersCount, uint childrenCount, List<EmployeeOccupation> employeeOccupation, List<DepartmentEmployee> departmentEmployee, List<EmployeeVacationVoucher> employeeVacationVoucher)
    {
        Id = id;
        this.regNumber = regNumber;
        FirstName = firstName;
        LastName = lastName;
        PatronymicName = patronymicName;
        BirthDate = birthDate;
        Workshop = workshop;
        HomeAddress = homeAddress;
        HomeTelephone = homeTelephone;
        WorkTelephone = workTelephone;
        FamilyStatus = familyStatus;
        FamilyMembersCount = familyMembersCount;
        ChildrenCount = childrenCount;
        EmployeeOccupation = employeeOccupation;
        DepartmentEmployee = departmentEmployee;
        EmployeeVacationVoucher = employeeVacationVoucher;
    }
}