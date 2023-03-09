﻿namespace UniversityData.Domain;
/// <summary>
/// Информация о кафедре
/// </summary>
public class Department
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название кафедры
    /// </summary>
    public string DepartmentName { get; set; } = string.Empty;
    /// <summary>
    /// Контактный телефон заведущего кафедрой
    /// </summary>
    public string DepartmentSupervisorNumber { get; set; } = string.Empty;
    /// <summary>
    /// Ссылка на обратную связь
    /// </summary>
    public University? University { get; set; }
}
