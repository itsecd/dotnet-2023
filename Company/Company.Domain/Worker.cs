using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain;

/// <summary>
/// Class Worker represents a Worker in Company; also store personal information and lists of other classes
/// </summary>
public class Worker
{
    /// <summary>
    /// Id - Identificator for each Worker
    /// </summary>
    [Key]
    public int Id { get; set; }


    /// <summary>
    /// RegistrationNumber - registration number of a Worker
    /// </summary>
    [Required]
    public int RegistrationNumber { get; set; }


    /// <summary>
    /// LastName - last name of a Worker
    /// </summary>
    [Required]
    public string LastName { get; set; } = string.Empty;


    /// <summary>
    /// FirstName - first name of a Worker
    /// </summary>
    [Required]
    public string FirstName { get; set; } = string.Empty;


    /// <summary>
    /// LastName - patronymic name of a Worker
    /// </summary>
    [Required]
    public string Patronymic { get; set; } = string.Empty;


    /// <summary>
    /// BirthDate - birth date of a Worker
    /// </summary>
    [Required]
    public DateTime BirthDate { get; set; } = DateTime.MinValue;


    /// <summary>
    /// Sex - sex of a Worker (ex. "male", "female")
    /// </summary>
    [Required]
    public string Sex { get; set; } = string.Empty;


    /// <summary>
    /// WorkshopId - an id of the Workshop
    /// </summary>
    [ForeignKey("Workshop")]
    public int WorkshopId { get; set; }


    /// <summary>
    /// HomeAddress - home address of a Worker
    /// </summary>
    [Required]
    public string HomeAddress { get; set; } = string.Empty;


    /// <summary>
    /// HomeTelephone - home telephone of a Worker
    /// </summary>
    [Required]
    public string HomeTelephone { get; set; } = string.Empty;


    /// <summary>
    /// WorkTelephone - work telephone of a Worker
    /// </summary>
    [Required]
    public string WorkTelephone { get; set; } = string.Empty;


    /// <summary>
    /// MaritalStatus - family status of a Worker (ex. "married", "single")
    /// </summary>
    [Required]
    public string MaritalStatus { get; set; } = string.Empty;


    /// <summary>
    /// PeopleInFamily - number of people in the Worker's family
    /// </summary>
    [Required]
    public int PeopleInFamily { get; set; } = 1;


    /// <summary>
    /// ChildrenInFamily - number of the Worker's children
    /// </summary>
    [Required]
    public int ChildrenInFamily { get; set; } = 0;


    /// <summary>
    /// WorkerDepartments - a list of Departments, in which this Worker is currently working
    /// One Worker can work in multiple departments
    /// </summary>
    public List<WorkersAndDepartments> WorkerDepartments { get; set; } = new List<WorkersAndDepartments>();


    /// <summary>
    /// WorkerJobs - a list of Worker's jobs; also includes dates of hire and dismissal
    /// </summary>
    public List<WorkersAndJobs> WorkerJobs { get; set; } = new List<WorkersAndJobs>();


    /// <summary>
    /// WorkerVacations – a list of Worker's Vacations; also includes date of issue
    /// </summary>
    public List<WorkersAndVacations> WorkerVacations { get; set; } = new List<WorkersAndVacations>();
}