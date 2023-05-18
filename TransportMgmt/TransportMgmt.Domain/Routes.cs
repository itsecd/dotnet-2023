using System.ComponentModel.DataAnnotations;

namespace TransportMgmt.Domain;
/// <summary>
/// Class Route is used to store information about routes
/// </summary>
public class Routes
{
    /// <summary>
    /// Unique key of route
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Route number
    /// </summary>
    [Required]
    public string RouteNumber { get; set; } = string.Empty;

}
