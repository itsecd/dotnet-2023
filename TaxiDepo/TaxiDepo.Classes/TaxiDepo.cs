using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDepo.Domain;

public class TaxiDepot
{
    /// <summary>
    /// Drivers who are registered in the taxi company
    /// </summary>
    public List<Driver> Drivers { get; set; } = new List<Driver>();
    /// <summary>
    /// Cars who are registered in the taxi company
    /// </summary>
    public List<Car> Cars { get; set; } = new List<Car>();
    /// <summary>
    /// Peoples that are used the taxi company
    /// </summary>
    public List<User> Users { get; set; } = new List<User>();
    /// <summary>
    /// Taxi company's trip info
    /// </summary>
    public List<Ride> Rides { get; set; } = new List<Ride>();
    /// <summary>
    /// Constructor without parameters to instantiate the class TaxiDepot
    /// </summary>
    public TaxiDepot() {}
    /// <summary>
    /// Constructor with parameters to instantiate the class TaxiDepot
    /// </summary>
    /// <param name="driverObj">List of drivers(Driver class object)</param>
    /// <param name="carObj">List of cars(Car class object)</param>
    /// <param name="userObj">List of users(User class object)</param>
    /// <param name="rideObj">List of rides(Ride class object)</param>
    public TaxiDepot(List<Driver> driverObj, List<Car> carObj, List<User> userObj, List<Ride> rideObj)
    {
        Drivers = driverObj;
        Cars = carObj;
        Users = userObj;
        Rides = rideObj;
    }
}