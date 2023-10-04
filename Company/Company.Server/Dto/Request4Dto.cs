namespace Company.Server.Dto;

/// <summary>
/// Сontains data on request #4 (learn more in the RequestsController)
/// </summary>
public class Request4Dto
{
    /// <summary>
    /// DepartmentName - name of Department of the Worker
    /// </summary>
    public string? DepartmentName { get; set; }

    /// <summary>
    /// AverageAge - average age of Workers in the Department
    /// </summary>
    public double AverageAge { get; set; }

}