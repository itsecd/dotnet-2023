﻿namespace UniversityData.Domain;
/// <summary>
/// Специальность
/// </summary>
public class Specialty
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название специальности
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Код-шифр специальности 
    /// </summary>
    public string Code { get; set; }
}
