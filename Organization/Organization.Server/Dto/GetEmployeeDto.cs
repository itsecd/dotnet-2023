namespace Organization.Server.Dto;
/// <summary>
/// Classs PostEmployeeDto represents an employee in organization, it contains personal information.
/// </summary>
public class GetEmployeeDto
{
    /// <summary>
    /// Id - Identificator for each Employee object
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// RegNumber - registration number of an Employee
    /// </summary>
    public uint RegNumber { get; set; }
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
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    /// <summary>
    /// Workshop - an id of the Workshop
    /// </summary>
    public int WorkshopId { get; set; }
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
}