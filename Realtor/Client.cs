using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realtor;
/// <summary>
/// ClientType sellers and buyers of the real estate agency
/// </summary>
public class Client
{
    /// <summary>
    /// Id - int typed value for storing Id of the client
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; } = int.MinValue;
    /// <summary>
    /// Passport - a string representing passport number
    /// </summary>
    [Column("passport")]
    public string Passport { get; set; } = string.Empty;
    /// <summary>
    /// Number - a string for contact number
    /// </summary> 
    [Column("number")] 
    public string Number { get; set; } = string.Empty;
    /// <summary>
    /// Registration- a string for customer registration address
    /// </summary> 
    [Column("registration")] 
    public string Registration { get; set; } = string.Empty;
    /// <summary>
    /// Name, Surname - a string for name and surname optionally
    /// </summary> 
    [Column("name")] 
    public string Name { get; set; } = string.Empty;
    [Column("surname")] 
    public string Surname { get; set; } = string.Empty;
    public List<Application> Applications { get; set; } = new();
    public Client() { }
    public Client(int id, string passport, string number, string registration, string name, string surname)
    {
        Id = id;
        Passport = passport;
        Number = number;
        Registration = registration;
        Name = name;
        Surname = surname;
    }
}