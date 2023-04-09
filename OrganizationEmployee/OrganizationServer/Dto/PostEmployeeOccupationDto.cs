namespace OrganizationServer.Dto;
/// <summary>
/// class PostEmployeeOccupationDto - represents a many-to-many relationship
/// between Employee and Occupation, also it contains date, when an employee was hired, and date, when employee was dismissed.
/// </summary>
public class PostEmployeeOccupationDto
{
    /// <summary>
    /// HireDate - a date, when an employee was hired on the given occupation.
    /// </summary>
    public DateTime HireDate { get; set; }
    /// <summary>
    /// DismissalDate - a date, when an employee was dismissed from the occupation.
    /// Can be null if the employee is still working on that job.
    /// </summary>
    public DateTime? DismissalDate { get; set; }
    /// <summary>
    /// OccupationId - an id of Occupation object
    /// </summary>
    public uint? OccupationId { get; set; }
    /// <summary>
    /// EmployeeId - an id of Employee object
    /// </summary>
    public uint? EmployeeId { get; set; }
}