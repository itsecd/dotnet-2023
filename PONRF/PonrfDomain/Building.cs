using System.ComponentModel.DataAnnotations;

namespace PonrfDomain;

/// <summary>
/// Class Building describes a building 
/// </summary>
public class Building
{
    /// <summary>
    /// Id is an identifier of building
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// RegistNum contains information about registration number of building
    /// </summary>
    [Required]
    public string RegistNum { get; set; } = string.Empty;
    /// <summary>
    /// District contains information about district where the building is located
    /// </summary> 
    [Required]
    public string District { get; set; } = string.Empty;
    /// <summary>
    /// Street contains information about street where the building is located
    /// </summary>
    [Required]
    public string Street { get; set; } = string.Empty;
    /// <summary>
    /// HouseNumber contains information about house number of building
    /// </summary>
    [Required]
    public int HouseNumber { get; set; }
    /// <summary>
    /// Area contains information about building area
    /// </summary>
    [Required]
    public int Area { get; set; }
    /// <summary>
    /// Floors contains information about number of floors of the building
    /// </summary>
    [Required]
    public int Floors { get; set; }
    /// <summary>
    /// DateOfBuild contains information about date of construction of the building
    /// </summary>
    [Required]
    public DateTime DateOfBuild { get; set; } = DateTime.MinValue;
    /// <summary>
    /// List of all privatized buildings
    /// </summary>
    public List<PrivatizedBuilding> PrivatizedBuilding { get; set; }
}
