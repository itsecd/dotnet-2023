namespace Company.Server.Dto;

/// <summary>
/// WorkersAndJobsGetDto - narrows the WorkersAndJobs class for Get method in controller
/// </summary>
public class WorkersAndJobsGetDto
{
    /// <summary>
    /// Id - an id of the class object
    /// </summary>
    public int Id { get; set; }


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
