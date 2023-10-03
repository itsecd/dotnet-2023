namespace Company.Server.Dto;

/// <summary>
/// JobGetDto - narrows the Job class for Get method in controller
/// </summary>
public class JobGetDto
{
    /// <summary>
    /// Id - an id of the Job
    /// </summary>
    public int Id { get; set; }


    /// <summary>
    /// Name - a name of the Job
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
