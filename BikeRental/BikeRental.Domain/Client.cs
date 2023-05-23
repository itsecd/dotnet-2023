using System.ComponentModel.DataAnnotations.Schema;

namespace BikeRental.Domain;

/// <summary>
/// Class Client has the info about a client who rented bikes
/// </summary>
[Table("client")]
public class Client
{
    /// <summary>
    /// Id of a client
    /// </summary>
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// A full name of a client
    /// </summary>
    [Column("full_name")]
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Client's year of birth
    /// </summary>
    [Column("birth_year")]
    public int BirthYear { get; set; }

    /// <summary>
    /// Client's phone number
    /// </summary>
    [Column("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;
}
