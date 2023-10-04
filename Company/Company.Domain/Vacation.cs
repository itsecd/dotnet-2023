using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain;

/// <summary>
/// Vacation - represents a Worker's Vacation
/// </summary>
public class Vacation
{
    /// <summary>
    /// Id - an id of the Vacation
    /// </summary>
    [Key]
    public int Id { get; set; }


    /// <summary>
    /// Id - an id of the VacationSpot
    /// </summary>
    [ForeignKey("VacationSpot")]
    public int VacationSpotId { get; set; }


    /// <summary>
    /// IssueDate - a date of the issue
    /// </summary>
    [Required]
    public DateTime IssueDate { get; set; } = DateTime.MinValue;


    /// <summary>
    /// VacationWorkers - a list of Workers, which had vacations
    /// </summary>
    public List<WorkersAndVacations> VacationWorkers { get; set; } = new List<WorkersAndVacations>();
}

