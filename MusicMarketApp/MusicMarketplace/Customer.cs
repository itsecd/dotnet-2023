using System.ComponentModel.DataAnnotations;

namespace MusicMarketplace;

/// <summary>
/// Покупатель.
/// </summary>
public class Customer
{
    /// <summary>
    /// ID Покупателя.
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;

    /// <summary>
    /// Ф.И.О.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Страна проживания.
    /// </summary>
    [Required]
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// Адрес.
    /// </summary>
    [Required]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Конструктор по умолчанию. 
    /// </summary>
    public Customer() { }
    /// <summary>
    /// Конструктор с параметрами. 
    /// </summary>
    public Customer(int id, string name, string country, string address)
    {
        Id = id;
        Name = name;
        Country = country;
        Address = address;
    }
}
