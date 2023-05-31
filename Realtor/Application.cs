using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realtor;
public class Application
{
    /// <summary>
    /// Id - int typed value for storing Id of the application
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; } = int.MinValue;
    /// <summary>
    /// Type - string typed value representing a type of the room
    /// </summary>
    [Column("type")]
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// Cost - uint for storing a cost of the room
    /// </summary>
    [Column("cost")]
    public uint Cost { get; set; } = uint.MinValue;
    /// <summary>
    /// Data - DateTime typed value for storing a date of application
    /// </summary>
    [Column("data")]
    public DateTime Data { get; set; } = DateTime.MinValue;
    public Client? Clients { get; set; }
    [ForeignKey("Client")]
    [Column("client_id")]
    public int ClientId { set; get; }
    public List<ApplicationHasHouse> ApplicationHasHouses { get;set; } = new List<ApplicationHasHouse>();
   
    public Application() { }
    public Application(int id, string type, uint cost, DateTime data, int clientId)
    {
        Id = id;
        Type = type;
        Cost = cost;
        Data = data;
        ClientId=clientId;
      
    }
}