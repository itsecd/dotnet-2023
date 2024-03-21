namespace Library.Domain;

/// <summary>
/// Тип отдела
/// </summary>
public class TypeDepartment
{
    /// <summary>
    /// Идентификатор отдела
    /// </summary>
    public int Id { set; get; }
    
    /// <summary>
    /// Наименование типа
    /// </summary>
    public string Name { set; get; } = string.Empty;

    /// <summary>
    /// Список отделов данного типа
    /// </summary>
    public List<Department> Departments { set; get; } = new List<Department>();
}
