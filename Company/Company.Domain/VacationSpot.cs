using System.ComponentModel.DataAnnotations;

namespace Company.Domain;

/// <summary>
/// VacationSpot - represents a type of Vacation Spot
/// </summary>
public class VacationSpot
{
    /// <summary>
    /// Id - an id of the VacationSpot
    /// </summary>
    [Key]
    public int Id { get; set; }


    /// <summary>
    /// Name - a name of the VacationSpot
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
}
