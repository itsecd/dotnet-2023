using System.ComponentModel.DataAnnotations;

namespace Company.Domain;

/// <summary>
/// Class Workshop describes a workshop in the Company
/// </summary>
public class Workshop
{
    /// <summary>
    /// Id - an id of the Workshop
    /// </summary>
    [Key]
    public int Id { get; set; }


    /// <summary>
    /// Name - a name of the Workshop
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;


    /// <summary>
    /// Workers - a list of Worker objects, used to maintain an one-to-many relationship
    /// </summary>
    public List<Worker> Workers { get; set; } = new List<Worker>();
}
