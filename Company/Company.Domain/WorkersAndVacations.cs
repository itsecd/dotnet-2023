using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain;

/// <summary>
/// class WorkersAndVacations represents a many-to-many relationship between Workers And Vacations
/// </summary>
public class WorkersAndVacations
{
    /// <summary>
    /// Id - an id of the link
    /// </summary>
    [Key]
    public int Id { get; set; }


    /// <summary>
    /// WorkerId - an id of Worker object
    /// </summary>
    [ForeignKey("Worker")]
    public int WorkerId { get; set; }


    /// <summary>
    /// Worker - a link to Worker object
    /// </summary>
    public Worker? Worker { get; set; }


    /// <summary>
    /// VacationId - an id of Vacation object
    /// </summary>
    [ForeignKey("Vacation")]
    public int VacationId { get; set; }


    /// <summary>
    /// Vacation - a link to Vacation object
    /// </summary>
    public Vacation? Vacation { get; set; }
}
