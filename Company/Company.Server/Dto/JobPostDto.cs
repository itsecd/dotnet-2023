namespace Company.Server.Dto;

/// <summary>
/// JobPostDto - narrows the Job class for Post method in controller
/// </summary>
public class JobPostDto
{
    /// <summary>
    /// Name - a name of the Job
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
