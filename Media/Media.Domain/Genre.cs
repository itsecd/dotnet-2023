using System.ComponentModel.DataAnnotations;

namespace Media.Domain;

/// <summary>
/// Class Genre is used to store information of the genre
/// </summary>
public class Genre
{
    /// <summary>
    /// Id is used to store a unique identifier 
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Name is used to store a name of genre
    /// </summary>
    [Required]
    public string Name { get; set; }
}
