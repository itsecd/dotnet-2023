namespace Company.Server.Dto;

/// <summary>
/// WorkersAndJobsPostDto - narrows the WorkersAndJobs class for Post method in controller
/// </summary>
public class WorkersAndJobsPostDto
{
    /// <summary>
    /// HireDate - a date, when a Worker was hired on the Job
    /// </summary>
    public DateTime HireDate { get; set; }


    /// <summary>
    /// DismissalDate - a date, when a Worker was dismissed from the Job
    /// (can be null, if the Worker is still working on that Job)
    /// </summary>
    public DateTime DismissalDate { get; set; } = DateTime.MaxValue;


    /// <summary>
    /// WorkerId - an id of Worker object
    /// </summary>
    public int WorkerId { get; set; }


    /// <summary>
    /// JobId - an id of Job object
    /// </summary>
    public int JobId { get; set; }
}
