using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Realtor;
/// <summary>
/// ApplicationHasHouse - a class for implementing the connection between houses and applications
/// </summary>
public class ApplicationHasHouse
{
    /// <summary>
    /// Id - int typed value for storing Id of the applicationHasHouse
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }= int.MinValue;
    
    public Application Applications { get; set; }
    /// <summary>
    /// ApplicationId - int typed value for storing Id of the application
    /// </summary>
    [ForeignKey("Application")]
    [Column("application_id")]
    public int ApplicationId { get; set; } = int.MinValue;
    public House Houses { get; set; }
    /// <summary>
    /// HouseId - int typed value for storing Id of the house
    /// </summary>
    [ForeignKey("House")]
    [Column("house_id")]
    public int HouseId { get; set; } = int.MinValue;
    public ApplicationHasHouse() { }
    public ApplicationHasHouse(int id, int applicationId, int houseId)
    {
        Id = id;
        ApplicationId = applicationId;
        HouseId = houseId;
    }
}
