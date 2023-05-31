using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realtor;
public class House
{
    /// <summary>
    /// Id - guid typed value for storing Id of the houses
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Type - a string type of object for sale - residential or non-residential
    /// </summary>
    [Column("type")]
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// Address - a string for address of the property being sold
    /// </summary>
    [Column("address")]
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// Square - uint value for object area
    /// </summary>
    [Column("square")] 
    public int Square { get; set; }
    /// <summary>
    /// Rooms - uint value for storing an amount of rooms of this type
    /// </summary>
    [Column("rooms")]
    public int Rooms { get; set; }
    public List<ApplicationHasHouse> ApplicationHasHouses { get; set; } = new List<ApplicationHasHouse>();
    
    public House() { }
    public House(int id, string type, string address, int square, int rooms)
    {
        Id = id;
        Type = type;
        Address = address;
        Square = square;
        Rooms = rooms;
        
    }
}