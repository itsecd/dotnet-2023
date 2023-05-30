using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiDepo.Model;

/// <summary>
/// Ride class
/// </summary>
[Table("Rides")]
public class Ride
{
    /// <summary>
    /// Ride id
    /// </summary>
    [Column("Id")]
    [Key]
    public int Id { get; set; } = 0;

    /// <summary>
    /// Departure place 
    /// </summary>
    [Column("TripDeparturePlace")]
    [Required]
    [MaxLength(45)]
    public string TripDeparturePlace { get; set; } = string.Empty;

    /// <summary>
    /// Destination place
    /// </summary>
    [Column("TripDestinationPlace")]
    [Required]
    [MaxLength(45)]
    public string TripDestinationPlace { get; set; } = string.Empty;

    /// <summary>
    /// Trip date
    /// </summary>
    [Column("TripDate")]
    [Required]
    public DateTime TripDate { get; set; }

    /// <summary>
    /// Trip time
    /// </summary>
    [Column("TripTime")]
    [Required]
    public double TripTime { get; set; }

    /// <summary>
    /// Trip price
    /// </summary>
    [Column("TripPrice")]
    [Required]
    public double TripPrice { get; set; } = 0.0;

    /// <summary>
    /// Trip carId 
    /// </summary>
    [Column("CarId")]
    [ForeignKey("Car")]
    public int CarId { get; set; }

    /// <summary>
    /// Trip userId 
    /// </summary>
    [Column("UserId")]
    [ForeignKey("User")]
    public int UserId { get; set; }

    /// <summary>
    /// Assigned car
    /// </summary>
    public Car TripCar { get; set; }

    /// <summary>
    /// Information about the user who made this trip
    /// </summary>
    public User UserInfo { get; set; }

    /// <summary>
    /// Constructor without parameters to instantiate the class Ride
    /// </summary>
    public Ride()
    {
    }

    /// <summary>
    /// Constructor with parameters to instantiate the class Ride
    /// </summary>
    /// <param name="id">Ride</param>
    /// <param name="departurePlace">Departure place of trip</param>
    /// <param name="destinationPlace">Destination place of trip</param>
    /// <param name="date">Date trip</param>
    /// <param name="time">Trip time</param>
    /// <param name="price">Trip price</param>
    /// <param name="auto">Trip assigned auto</param>
    /// <param name="user">User data</param>
    public Ride(int id, string departurePlace, string destinationPlace, DateTime date, double time, double price,
        Car auto, User user)
    {
        Id = id;
        TripDeparturePlace = departurePlace;
        TripDestinationPlace = destinationPlace;
        TripDate = date;
        TripTime = time;
        TripPrice = price;
        TripCar = auto;
        UserInfo = user;
    }

    /// <summary>
    /// Overload Equals
    /// </summary>
    /// <param name="rideObj">Ride class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public override bool Equals(object? rideObj)
    {
        if (rideObj is not Ride param || GetType() != rideObj.GetType()) return false;

        return TripDeparturePlace == param.TripDeparturePlace && TripDestinationPlace == param.TripDestinationPlace &&
               TripDate == param.TripDate && TripTime == param.TripTime && TripPrice == param.TripPrice &&
               TripCar == param.TripCar;
    }

    /// <summary>
    /// Overload == through Equals
    /// </summary>
    /// <param name="rideObj1">Ride class object</param>
    /// <param name="rideObj2">Ride class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public static bool operator ==(Ride rideObj1, Ride rideObj2)
    {
        return Object.Equals(rideObj1, rideObj2);
    }

    /// <summary>
    /// Overload != through Equals
    /// </summary>
    /// <param name="rideObj1">Ride class object</param>
    /// <param name="rideObj2">Ride class object</param>
    /// <returns>True - not equal or false - equal</returns>
    public static bool operator !=(Ride rideObj1, Ride rideObj2)
    {
        return !Object.Equals(rideObj1, rideObj2);
    }

    /// <summary>
    /// Get hash code function
    /// </summary>
    /// <returns>Integer hash code</returns>
    public override int GetHashCode()
    {
        return TripPrice.GetHashCode();
    }
}


