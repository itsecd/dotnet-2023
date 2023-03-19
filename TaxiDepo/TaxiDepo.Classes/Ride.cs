namespace TaxiDepo.Domain;

public class Ride
{
    /// <summary>
    /// Departure place 
    /// </summary>
    public string TripDeparturePlace { get; set; } = string.Empty;
    /// <summary>
    /// Destination place
    /// </summary>
    public string TripDestinationPlace { get; set; } = string.Empty;
    /// <summary>
    /// Trip date
    /// </summary>
    public DateTime? TripDate { get; set; }
    /// <summary>
    /// Trip time
    /// </summary>
    public TimeSpan? TripTime { get; set; }
    /// <summary>
    /// Trip price
    /// </summary>
    public double TripPrice { get; set;  } = 0.0;
    /// <summary>
    /// Assigned car
    /// </summary>
    public Car? TripCar { get; set; }
    /// <summary>
    /// Constructor without parameters to instantiate the class Ride
    /// </summary>
    public Ride() {}
    /// <summary>
    /// Constructor with parameters to instantiate the class Ride
    /// </summary>
    /// <param name="departurePlace">Departure place of trip</param>
    /// <param name="destinationPlace">Destination place of trip</param>
    /// <param name="date">Date trip</param>
    /// <param name="time">Trip time</param>
    /// <param name="price">Trip price</param>
    /// <param name="auto">Trip assigned auto</param>
    public Ride(string departurePlace, string destinationPlace, DateTime date, TimeSpan time, double price, Car auto)
    {
        TripDeparturePlace = departurePlace;
        TripDestinationPlace = destinationPlace;
        TripDate = date;
        TripTime = time;
        TripPrice = price;
        TripCar = auto;
    }
    /// <summary>
    /// Overload Equals
    /// </summary>
    /// <param name="rideObj">Ride class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public override bool Equals(object? rideObj)
    {
        if (rideObj is not Ride param || GetType() != rideObj.GetType())
            return false;

        return TripDeparturePlace == param.TripDeparturePlace &&
               TripDestinationPlace == param.TripDestinationPlace &&
               TripDate == param.TripDate &&
               TripTime == param.TripTime &&
               TripPrice == param.TripPrice &&
               TripCar == param.TripCar;
    }
    /// <summary>
    /// Overload == through Equals
    /// </summary>
    /// <param name="rideObj1">Ride class object</param>
    /// <param name="rideObj2">Ride class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public static bool operator==(Ride rideObj1, Ride rideObj2)        
    {            
        return Object.Equals(rideObj1, rideObj2);        
    }
    /// <summary>
    /// Overload != through Equals
    /// </summary>
    /// <param name="rideObj1">Ride class object</param>
    /// <param name="rideObj2">Ride class object</param>
    /// <returns>True - not equal or false - equal</returns>
    public static bool operator!=(Ride rideObj1, Ride rideObj2)        
    {            
        return !Object.Equals(rideObj1, rideObj2);        
    }
    /// <summary>
    /// Print function
    /// </summary>
    /// <param name="obj">Ride class object</param>
    public void PrintCarData(Ride obj)
    {
        Console.WriteLine($"Departure place: {obj.TripDeparturePlace}, Destination place - {obj.TripDestinationPlace}, date - {obj.TripDate}, time - {obj.TripTime}, price - {obj.TripPrice}, assigned car - {obj.TripCar}");
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