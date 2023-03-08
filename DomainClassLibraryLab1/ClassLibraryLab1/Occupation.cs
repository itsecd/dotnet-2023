﻿namespace EmployeeDomain;
/// <summary>
/// Occupation - represents an employee occupation.
/// The class has list of EmployeeOccupation objects for many-to-many relationship.
/// </summary>
public class Occupation
{
    /// <summary>
    /// Id - an id of the occupation
    /// </summary>
    public uint Id { get; set; }
    /// <summary>
    /// Name - a name of the given occupation
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// EmployeeOccupation - a list of EmployeeOccupation objects, used for many-to-many relationship.
    /// </summary>
    public List<EmployeeOccupation> EmployeeOccupation { get; set; } = new List<EmployeeOccupation>();
}