using System.ComponentModel.DataAnnotations;

namespace Company.Domain;

/// <summary>
/// Job - represents a Worker's Job
/// </summary>
public class Job
{
    /// <summary>
    /// Id - an id of the Job
    /// </summary>
    [Key]
    public int Id { get; set; }


    /// <summary>
    /// Name - a name of the Job
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;


    /// <summary>
    /// JobWorkers - a list of Workers, which are currently have this Job
    /// </summary>
    public List<WorkersAndJobs> JobWorkers { get; set; } = new List<WorkersAndJobs>();
}
