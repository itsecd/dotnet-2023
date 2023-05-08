using System.ComponentModel.DataAnnotations;

namespace PonrfDomain;

/// <summary>
/// Class Customer describes a customer
/// </summary>
public class Customer
{
    /// <summary>
    /// Id is an identifier of customer
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Passport contains information about passport's number of customer
    /// </summary>
    [Required]
    public string Passport { get; set; } = string.Empty;
    /// <summary>
    /// FIO contains information about full name of customer
    /// </summary>  
    [Required]
    public string Fio { get; set; } = string.Empty;
    /// <summary>
    /// Address contains information about home address of customer
    /// </summary>
    [Required]
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// List of all purchased buildings
    /// </summary>
    public List<PrivatizedBuilding>? PrivatizedBuilding { get; set; }

    /// <summary>
    /// Constructor for Customer
    /// </summary>
    public Customer() { }
    /// <summary>
    /// Constructor for Customer with parameters
    /// </summary>
    /// <param name="id"></param>
    /// <param name="passport"></param>
    /// <param name="fio"></param>
    /// <param name="address"></param>
    public Customer(int id, string passport, string fio, string address)
    {
        Id = id;
        Passport = passport;
        Fio = fio;
        Address = address;
    }
}
