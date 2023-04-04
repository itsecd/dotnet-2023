namespace OrganizationEmployee.Server.Dto;
/// <summary>
/// ArchiveOfDismissals represents an archive of dismissed employees
/// </summary>
public class ArchiveOfDismissalsDto
{
    /// <summary>
    /// RegNumber - registration number of an Employee
    /// </summary>
    public uint? RegNumber { get; set; }
    /// <summary>
    /// FirstName - first name of an Employee
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// LastName - last name of an Employee
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// LastName - patronymic name of on Employee
    /// </summary>
    public string? PatronymicName { get; set; }
    /// <summary>
    /// BirthDate - birth date of an Employee
    /// </summary>
    public DateTime? BirthDate { get; set; }
    /// <summary>
    /// Workshop - an id of the Workshop
    /// </summary>
    public string? WorkshopName { get; set; }
    /// <summary>
    /// DepartmentName - a name of department of the Employee
    /// </summary>
    public string? DepartmentName { get; set; }
    /// <summary>
    /// OccupationName - a name of occupation of the Employee
    /// </summary>
    public string? OccupationName { get; set; }

}