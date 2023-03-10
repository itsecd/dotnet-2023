namespace EmployeeDomain;
/// <summary>
/// class EmployeeOccupation - represents a many-to-many relationship
/// between Employee and Occupation, also it contains date, when an employee was hired, and date, when employee was dismissed.
/// </summary>
public class EmployeeOccupation
{
    /// <summary>
    /// Id - an id of the class object
    /// </summary>
    public uint Id { get; set; }
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
    /// Occupation - a link to Occupation object, used for many-to-many relationship
    /// </summary>
    public Occupation? Occupation { get; set; }
    /// <summary>
    /// Employee - a link to Employee object, used for many-to-many relationship
    /// </summary>
    public Employee? Employee { get; set; }
}