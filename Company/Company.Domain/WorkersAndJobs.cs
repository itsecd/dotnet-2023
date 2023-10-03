
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain;


/// <summary>
/// class WorkersAndJobs represents a many-to-many relationship between Workers and Jobs; 
/// also contains date, when a Worker was hired (and date, when Worker was dismissed)
/// </summary>

public class WorkersAndJobs
{
    /// <summary>
    /// Id - an id of the class object
    /// </summary>
    [Key]
    public int Id { get; set; }


    /// <summary>
    /// HireDate - a date, when a Worker was hired on the Job
    /// </summary>
    [Required]
    public DateTime HireDate { get; set; }


    /// <summary>
    /// DismissalDate - a date, when a Worker was dismissed from the Job
    /// (can be 9999.12.31, if the Worker is still working on that Job)
    /// </summary>
    [Required]
    public DateTime DismissalDate { get; set; } = new DateTime(9999, 12, 31);


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
    /// JobId - an id of Job object
    /// </summary>
    [ForeignKey("Job")]
    public int JobId { get; set; }


    /// <summary>
    /// Job - a link to Job object
    /// </summary>
    public Job? Job { get; set; }
}