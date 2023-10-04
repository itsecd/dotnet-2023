namespace Company.Server.Dto;

/// <summary>
/// Сontains data on request #3 (learn more in the RequestsController)
/// </summary>
public class Request3Dto
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
    /// LastName - patronymic name of a Worker
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// BirthDate - birth date of a Worker
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// DepartmentName - name of Department of the Worker
    /// </summary>
    public string? DepartmentName { get; set; }

    /// <summary>
    /// JobName - name of Job of the Worker
    /// </summary>
    public string? JobName { get; set; }

    /// <summary>
    /// WorkshopName - name of Workshop of the Worker
    /// </summary>
    public string? WorkshopName { get; set; }

    /// <summary>
    /// DismissalDate - a date, when a Worker was dismissed from the Job
    /// (can be 9999.12.31, if the Worker is still working on that Job)
    /// </summary>
    public DateTime? DismissalDate { get; set; }
}