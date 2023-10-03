namespace Company.Server.Dto;

/// <summary>
/// Сontains data on request #5 (learn more in the RequestsController)
/// </summary>
public class Request5Dto
{
    /// <summary>
    /// Id - Identificator for each Worker
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// RegistrationNumber - registration number of a Worker
    /// </summary>
    public int? RegistrationNumber { get; set; }

    /// <summary>
    /// LastName - last name of a Worker
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// FirstName - first name of a Worker
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// IssueDate - a date of the issue
    /// </summary>
    public DateTime? IssueDate { get; set; }
}