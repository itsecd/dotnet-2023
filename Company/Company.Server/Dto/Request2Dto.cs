namespace Company.Server.Dto;

/// <summary>
/// Сontains data on request #2 (learn more in the RequestsController)
/// </summary>
public class Request2Dto
{
    /// <summary>
    /// Id - Identificator for each Worker
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// RegistrationNumber - registration number of a Worker
    /// </summary>
    public int RegistrationNumber { get; set; }

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
    /// NumberOfDepartments - number of Worker's Departments
    /// </summary>
    public int NumberOfDepartments { get; set; }
}