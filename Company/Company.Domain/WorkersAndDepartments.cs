using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain;

/// <summary>
/// class WorkersAndDepartments represents a many-to-many relationship between Workers and Departments
/// </summary>
public class WorkersAndDepartments
{
    /// <summary>
    /// Id - an id of the link
    /// </summary>
    [Key]
    public int Id { get; set; }


    /// <summary>
    /// WorkerId - an id of Worker object
    /// </summary>
    [ForeignKey("Worker")]
    public int WorkerId { get; set; }


    /// <summary>
    /// Worker - a link to Worker object
    /// </summary>
    public Worker? Worker { get; set; }


    /// <summary>
    /// DepartmentId - an id of Department object
    /// </summary>
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }


    /// <summary>
    /// Department - a link to Department object
    /// </summary>
    public Department? Department { get; set; }
}